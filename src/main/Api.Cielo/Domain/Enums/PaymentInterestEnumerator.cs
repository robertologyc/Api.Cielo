using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
{
    /// <summary>
    /// Interest Type (Tipo de parcelamento)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentInterestEnumerator
    {
        /// <summary>
        /// Store (Loja)
        /// </summary>
        ByMerchant,
        /// <summary>
        /// Provider (Cartão)
        /// </summary>
        ByIssuer
    }
}
