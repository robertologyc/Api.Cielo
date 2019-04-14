using Api.Cielo.Domain.Enums;
using Api.Cielo.Domain.Interfaces;

namespace Api.Cielo.Domain.Modules.Payment
{
    public class DebitCard: IValidate
    {
        public DebitCard()
        {

        }

        public DebitCard(Dto.DebitCard debitCard)
        {
            CardNumber = debitCard.CardNumber;
            Holder = debitCard.Holder;
            ExpirationDate = debitCard.ExpirationDate;
            SecurityCode = debitCard.SecurityCode;
            SaveCard = debitCard.SaveCard;
            Brand = debitCard.Brand;
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
            Code = "-1";
            if (string.IsNullOrEmpty(CardNumber))
            {
                Message = "Número do cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(Holder))
            {
                Message = "Nome impresso no cartão não pode ser branco";
                return false;
            }

            if (string.IsNullOrEmpty(ExpirationDate))
            {
                Message = "Data de validade do cartão não pode ser branco";
                return false;
            }

            if (!string.IsNullOrEmpty(SecurityCode)) return true;

            Message = "Código de segurança do cartão não pode ser branco";
            return false;
        }
    }
}
