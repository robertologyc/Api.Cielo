using System.Collections.Generic;
using Api.Cielo.Domain.Enums;

namespace Api.Cielo.Domain.Modules.Payment
{
    public class PaymentResponse: Payment
    {
        public string Url { get; set; }
        public string AuthenticationUrl { get; set; }
        public string ProofOfSale { get; set; }
        public string Tid { get; set; }
        public string AuthorizationCode { get; set; }
        public string PaymentId { get; set; }
        public StatusEnumerator? Status { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}
