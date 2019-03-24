using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Modules.Payment
{
    public class DebitCard
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
    }
}
