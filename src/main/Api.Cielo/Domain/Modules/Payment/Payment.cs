using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Payment
{
    public abstract class Payment
    {
        public PaymentTypeEnumerator Type { get; set; }
        public int Amount { get; set; }
        public CurrencyEnumerator Currency { get; set; }
        public string Country { get; set; }
        public int? ServiceTaxAmount { get; set; }
        public int Installments { get; set; }
        public PaymentInterestEnumerator? Interest { get; set; }
        public bool? Capture { get; set; }
        public bool? Authenticate { get; set; }
        public string SoftDescriptor { get; set; }
        public string ReturnUrl { get; set; }
        public ProviderEnumerator? Provider { get; set; }
        public CreditCard CreditCard { get; set; }
        public DebitCard DebitCard { get; set; }
    }
}
