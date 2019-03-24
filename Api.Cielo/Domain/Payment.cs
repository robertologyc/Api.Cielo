using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain
{
    public class Payment
    {
        public PaymentType Type { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public int ServiceTaxAmount { get; set; }
        public int Installments { get; set; }
        public bool Capture { get; set; }
        public bool Authenticate { get; set; }
        public string SoftDescriptor { get; set; }
    }
}
