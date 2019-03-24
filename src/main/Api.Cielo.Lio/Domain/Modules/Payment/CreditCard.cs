using Api.Cielo.Lio.Domain.Enums;
namespace Api.Cielo.Lio.Domain.Modules.Payment
{
    public class CreditCard
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
    }
}
