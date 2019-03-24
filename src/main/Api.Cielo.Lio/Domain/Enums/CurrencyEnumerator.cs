using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Lio.Domain.Enums
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
