namespace Api.Cielo.Domain.Modules.Commercial
{
    public abstract class Order
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
    }
}
