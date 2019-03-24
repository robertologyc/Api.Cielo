using Api.Cielo.Lio.Domain.Modules.Commercial;
using Api.Cielo.Lio.Domain.Modules.Payment.Factories;

namespace Api.Cielo.Lio.Domain.Dto
{
    public class Transaction
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public string SoftDescriptor { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}