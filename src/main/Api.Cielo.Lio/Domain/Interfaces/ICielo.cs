using Api.Cielo.Lio.Domain.Dto;
using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Interfaces
{
    public interface ICielo
    {
        void ConfigureEnvironment(string merchantId, string merchantKey, EnvironmentEnumerator environment);
        Response SendSaleOrder(Transaction order);
    }
}
