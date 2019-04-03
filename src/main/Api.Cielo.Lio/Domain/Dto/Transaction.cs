using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Interfaces;
using Api.Cielo.Lio.Domain.Modules.Commercial;
using Api.Cielo.Lio.Domain.Modules.Payment.Factories;

namespace Api.Cielo.Lio.Domain.Dto
{
    /// <summary>
    ///     Cria transação para enviar a Cielo
    /// </summary>
    public class Transaction: IValidate
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public string SoftDescriptor { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public string Code { get; set; }
        public string Message { get; set; }

        public bool IsValid()
        {
            Code = "-1";

            if (string.IsNullOrEmpty(MerchantOrderId))
            {
                Message = "Número do pedido da loja não pode ser vázio.";
                return false;
            }

            if (Customer == null)
            {
                Message = "Consumidor não encontrado.";
                return false;
            }

            if (PaymentMethod == null)
            {
                Message = "Método de pagamento não especificado.";
                return false;
            }

            if (PaymentMethod != null && PaymentMethod.Installments <= 0)
            {
                Message = "A parcela não podem ser menor ou igual a zero.";
                return false;
            }
            
            if (!IsValidCreditCard()) return false;

            if (!IsValidDebitCard()) return false;
            
            if (Amount > 0) return true;

            Message = "Total da ordem não pode ser igual ou menor que zero.";
            return false;

        }

        private bool IsValidCreditCard()
        {
            if (PaymentMethod != null &&
                PaymentMethod.Type == PaymentTypeEnumerator.CreditCard &&
                PaymentMethod.CreditCard == null)
            {
                Message = "Cartão de crédito não foi informado.";
                return false;
            }

            if (PaymentMethod != null &&
                PaymentMethod.Type == PaymentTypeEnumerator.CreditCard &&
                PaymentMethod.CreditCard != null &&
                !PaymentMethod.CreditCard.IsValid())
            {
                Code = PaymentMethod.CreditCard.Code;
                Message = PaymentMethod.CreditCard.Message;
                return false;
            }

            return true;
        }

        private bool IsValidDebitCard()
        {
            if (PaymentMethod != null &&
                PaymentMethod.Type == PaymentTypeEnumerator.DebitCard &&
                PaymentMethod.DebitCard == null)
            {
                Message = "Cartão de débito não foi informado.";
                return false;
            }

            if (PaymentMethod != null &&
                PaymentMethod.Type == PaymentTypeEnumerator.DebitCard &&
                PaymentMethod.CreditCard != null &&
                !PaymentMethod.DebitCard.IsValid())
            {
                Code = PaymentMethod.DebitCard.Code;
                Message = PaymentMethod.DebitCard.Message;
                return false;
            }

            return true;
        }
    }
}