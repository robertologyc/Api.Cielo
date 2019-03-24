using Newtonsoft.Json;

namespace Api.Cielo.Lio.Domain.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>Serailize the object to a JSON string</summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static string ToJson(this object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>Deserialize the JSON string to a typed object</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToDeserialize"></param>
        /// <returns></returns>
        public static T GetJson<T>(this string objectToDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(objectToDeserialize);
        }
    }
}
