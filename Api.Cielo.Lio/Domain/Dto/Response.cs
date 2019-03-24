using Api.Cielo.Lio.Domain.Enums;
using Api.Cielo.Lio.Domain.Modules.Commercial;

namespace Api.Cielo.Lio.Domain.Dto
{
    public class Response: OrderResponse
    {
        public ReturnCodeEnumerator ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }
}
