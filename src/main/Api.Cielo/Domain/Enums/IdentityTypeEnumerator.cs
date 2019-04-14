using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdentityTypeEnumerator
    {
        [Description("CPF")]  Cpf,
        [Description("CNPJ")] Cnpj
    }
}
