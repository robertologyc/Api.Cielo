using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Cielo.Domain.Enums
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
