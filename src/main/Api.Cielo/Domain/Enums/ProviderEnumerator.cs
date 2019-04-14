using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProviderEnumerator
    {
        Cielo,
        Bradesco,
        Bradesco2,
        BancoDoBrasil,
        BancoDoBrasil2,
        Santander,
        Itau,
        CitiBank,
        BRB,
        Caixa,
        BancooB,
        Simulado
    }
}
