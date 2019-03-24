using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Dto
{
    public class DebitCard
    {
        public BrandEnumerator Brand { get; set; }
        public bool? SaveCard { get; set; }
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
