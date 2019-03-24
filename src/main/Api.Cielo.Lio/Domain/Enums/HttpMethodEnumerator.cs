using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Lio.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HttpMethodEnumerator
    {
        Get,
        Head,
        Post,
        Put,
        Delete,
        Connect,
        Options,
        Trace,
        Patch       
    }
}
