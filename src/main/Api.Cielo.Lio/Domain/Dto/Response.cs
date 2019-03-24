using Api.Cielo.Lio.Domain.Enums;
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
        ///     <see cref="ReturnCodeEnumerator"/>
        /// </summary>
        public ReturnCodeEnumerator Code { get; set; }
        
        /// <summary>
        ///     Retorna mensagem de erro enviada pela Cielo
        /// </summary>
        public string Message { get; set; }
    }
}
