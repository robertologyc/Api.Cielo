using Api.Cielo.Domain.Enums;
using Api.Cielo.Domain.Interfaces;

namespace Api.Cielo.Domain.Modules.Payment
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

        public string Code { get; set; }
        public string Message { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(CardNumber))
            {
                Code = "-1";
                Message = "Número do cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(Holder))
            {
                Code = "-1";
                Message = "Nome impresso no cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(ExpirationDate))
            {
                Code = "-1";
                Message = "Data de validade do cartão não pode ser branco";
                return false;
            }

            if (!string.IsNullOrEmpty(SecurityCode)) return true;

            Code = "-1";
            Message = "Código de segurança do cartão não pode ser branco";
            return false;
        }
    }
}
