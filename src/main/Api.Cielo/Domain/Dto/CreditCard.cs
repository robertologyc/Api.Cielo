using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Dto
{
    public class CreditCard
    {
        public CreditCard()
        {
            Installments = 1;            
        }
        public BrandEnumerator Brand { get; set; }
        public int Installments { get; set; }
        public PaymentInterestEnumerator? Interest { get; set; }
        public bool Capture { get; set; }
        public bool? SaveCard { get; set; }
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
