using Api.Cielo.Domain.Modules.Payment;

namespace Api.Cielo.Domain.Modules.Commercial
{
    public class OrderRequest : Order
    {
        public PaymentRequest Payment { get; set; }
    }
}
