using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentTypeEnumerator
    {
        [Description("CreditCard")] CreditCard,
        [Description("DebitCard")] DebitCard,
        [Description("EletronicTransfer")] EletronicTransfer,
        [Description("Boleto")] Boleto
    }
}
