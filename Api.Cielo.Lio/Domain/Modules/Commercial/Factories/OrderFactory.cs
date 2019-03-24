using Api.Cielo.Lio.Domain.Dto;
using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Extensions;
using Api.Cielo.Lio.Domain.Modules.Commercial.Interfaces;
using Api.Cielo.Lio.Domain.Modules.Payment;

namespace Api.Cielo.Lio.Domain.Modules.Commercial.Factories
{
    public class OrderFactory : IOrder
    {
        public OrderRequest CreateOrderRequestCreditCard(Transaction transaction)
        {
            var orderRequest = OrderRequestParse(transaction);
            orderRequest.Payment.Type = PaymentTypeEnumerator.CreditCard;
            orderRequest.Payment.Capture = transaction.PaymentMethod.Capture;
            orderRequest.Payment.CreditCard = transaction.PaymentMethod.CreditCard;
            return orderRequest;
        }

        public OrderRequest CreateOrderRequestDebitCard(Transaction transaction, EnvironmentEnumerator environment)
        {
            var orderRequest = OrderRequestParse(transaction);
            orderRequest.Payment.Type = PaymentTypeEnumerator.DebitCard;
            orderRequest.Payment.DebitCard = transaction.PaymentMethod.DebitCard;
            orderRequest.Payment.Provider = environment == EnvironmentEnumerator.Sandbox ? ProviderEnumerator.Simulado : orderRequest.Payment.Provider;
            return orderRequest;
        }

        private OrderRequest OrderRequestParse(Transaction transaction)
        {
            return new OrderRequest
            {
                MerchantOrderId = transaction.MerchantOrderId,
                Customer = transaction.Customer,
                Payment = new PaymentRequest
                {
                    Amount = transaction.Amount.OnlyNumbers(),
                    Installments = transaction.PaymentMethod.Installments,
                    Interest = transaction.PaymentMethod.Interest,
                    SoftDescriptor = transaction.SoftDescriptor
                }
            };
        }
    }
}
