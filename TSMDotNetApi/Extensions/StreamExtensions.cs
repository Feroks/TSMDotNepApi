using System.IO;
using Newtonsoft.Json;

namespace TSMDotNetApi.Extensions
{
    internal static class StreamExtensions
    {
        internal static T DeserializeJson<T>(this Stream source)
        {
            using (var textReader = new StreamReader(source))
            using (var jsonReader = new JsonTextReader(textReader))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
