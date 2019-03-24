using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Lio.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BrandEnumerator
    {
        [Description("Visa")] Visa,
        [Description("Master")] Master,
        [Description("Amex")] Amex,
        [Description("Elo")] Elo,
        [Description("Aura")] Aura,
        [Description("JCB")] Jcb,
        [Description("Diners")] Diners,
        [Description("Discover")] Discover,
        [Description("Hipercard")] Hipercard
    }
}
