using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Interfaces;

namespace Api.Cielo.Lio.Domain.Modules.Payment
{
    public class CreditCard: IValidate
    {
        public CreditCard()
        {

        }

        public CreditCard(Dto.CreditCard creditCard)
        {
            CardNumber = creditCard.CardNumber;
            Holder = creditCard.Holder;
            ExpirationDate = creditCard.ExpirationDate;
            SecurityCode = creditCard.SecurityCode;
            SaveCard = creditCard.SaveCard;
            Brand = creditCard.Brand;
        }
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public bool? SaveCard { get; set; }
        public BrandEnumerator Brand { get; set; }

        public ReturnCodeEnumerator Code { get; set; }
        public string Message { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(CardNumber))
            {
                Code = ReturnCodeEnumerator.ApiInternalError;
                Message = "Número do cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(Holder))
            {
                Code = ReturnCodeEnumerator.ApiInternalError;
                Message = "Nome impresso no cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(ExpirationDate))
            {
                Code = ReturnCodeEnumerator.ApiInternalError;
                Message = "Data de validade do cartão não pode ser branco";
                return false;
            }

            if (!string.IsNullOrEmpty(SecurityCode)) return true;

            Code = ReturnCodeEnumerator.ApiInternalError;
            Message = "Código de segurança do cartão não pode ser branco";
            return false;
        }
    }
}
