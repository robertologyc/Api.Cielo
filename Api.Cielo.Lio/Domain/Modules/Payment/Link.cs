using Api.Cielo.Lio.Domain.Enums;

namespace Api.Cielo.Lio.Domain.Modules.Payment
{
    public class Link
    {        
        public HttpMethodEnumerator Method { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}
