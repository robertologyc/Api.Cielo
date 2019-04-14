using Api.Cielo.Domain.Enums;
using Api.Cielo.Domain.Modules.Payment;

namespace Api.Cielo.Domain.Dto
{
    /// <summary>
    ///     Retorna o resultado da requisição enviada à Cielo
    /// </summary>
    public class Response
    {
        public PaymentResponse Payment { get; set; }

        /// <summary>
        ///     Retorna o código da mensagem de retorno Cielo
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        ///     Retorna mensagem de erro enviada pela Cielo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Retorna o status da compra
        /// </summary>
        public StatusEnumerator Status { get; set; }
    }
}
