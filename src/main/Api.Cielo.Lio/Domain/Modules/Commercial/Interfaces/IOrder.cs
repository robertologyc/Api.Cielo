using Api.Cielo.Lio.Domain.Dto;
using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Modules.Commercial.Interfaces
{
    public interface IOrder
    {
        OrderRequest CreateOrderRequestCreditCard(Transaction transaction);
        OrderRequest CreateOrderRequestDebitCard(Transaction transaction, EnvironmentEnumerator environment);
    }
}
