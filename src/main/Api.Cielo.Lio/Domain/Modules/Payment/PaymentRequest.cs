namespace Api.Cielo.Lio.Domain.Modules.Payment
{
    public class PaymentRequest: Payment
    {
        public PaymentRequest()
        {
            Installments = 1;
        }
    }
}
