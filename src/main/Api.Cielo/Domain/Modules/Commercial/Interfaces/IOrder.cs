using Api.Cielo.Domain.Dto;
using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Commercial.Interfaces
{
    public interface IOrder
    {
        OrderRequest CreateOrderRequestCreditCard(Transaction transaction);
        OrderRequest CreateOrderRequestDebitCard(Transaction transaction, EnvironmentEnumerator environment);
    }
}
