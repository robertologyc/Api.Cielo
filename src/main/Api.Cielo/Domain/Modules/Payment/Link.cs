using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Payment
{
    public class Link
    {        
        public HttpMethodEnumerator Method { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}
