using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public Brand Brand { get; set; }
    }
}
