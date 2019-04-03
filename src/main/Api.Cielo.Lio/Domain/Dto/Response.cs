using Api.Cielo.Lio.Domain.Modules.Payment;

namespace Api.Cielo.Lio.Domain.Dto
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
    }
}
