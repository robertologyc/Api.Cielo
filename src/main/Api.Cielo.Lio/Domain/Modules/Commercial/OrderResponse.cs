using Api.Cielo.Lio.Domain.Modules.Payment;

namespace Api.Cielo.Lio.Domain.Modules.Commercial
{
    public class OrderResponse : Order
    {        
        public PaymentResponse Payment { get; set; }
    }
}
