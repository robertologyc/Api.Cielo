using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Dto
{
    public class DebitCard
    {
        public DebitCard()
        {
            Authenticate = true;
        }

        public BrandEnumerator Brand { get; set; }
        public bool? SaveCard { get; set; }
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string ReturnUrl { get; set; }
        public bool Authenticate { get; set; }
    }
}
