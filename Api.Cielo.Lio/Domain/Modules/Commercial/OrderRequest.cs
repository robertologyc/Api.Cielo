using Api.Cielo.Lio.Domain.Modules.Payment;

namespace Api.Cielo.Lio.Domain.Modules.Commercial
{
    public class OrderRequest : Order
    {
        public PaymentRequest Payment { get; set; }
    }
}
