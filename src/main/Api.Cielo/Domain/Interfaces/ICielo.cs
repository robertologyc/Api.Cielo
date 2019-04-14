using Api.Cielo.Domain.Dto;
using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Interfaces
{
    public interface ICielo
    {
        /// <summary>
        ///     Configura o ambiente com a Cielo
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchantKey"></param>
        /// <param name="environment"></param>
        void ConfigureEnvironment(string merchantId, string merchantKey, EnvironmentEnumerator environment);

        /// <summary>
        ///     Envia a requisição de pagamento para o ambiente da Cielo
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Response SendSaleOrder(Transaction order);

        /// <summary>
        ///     Consulta o status do pagamento
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        Response GetSaleOrder(string paymentId);

        /// <summary>
        ///     Cancela a compra no seu valor total
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        Response CancelTotalOrder(string paymentId);

        /// <summary>
        ///     Cancela a compra no seu valor parcial, só pode ser realizado para compras feitas com cartão de crédito com status Capturado.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        Response CancelPartialOrder(string paymentId, decimal amount);
    }
}
