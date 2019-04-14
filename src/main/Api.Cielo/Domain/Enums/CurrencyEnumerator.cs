using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyEnumerator
    {
        BRL,
        USD,
        MXN,
        COP,
        CLP,
        ARS,
        PEN,
        EUR,
        PYN,
        UYU,
        VEB,
        VEF,
        GBP
    }
}
