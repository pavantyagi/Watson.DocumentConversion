using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Watson.DocumentConversion.Enums;

namespace Watson.DocumentConversion.RequestBuilders
{
    internal class DocumentConversionRequestBuilder : RequestBuilderBase
    {
        /// <summary>
        ///     Builds a HttpRequestMessage based on the options provided.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="fileType"></param>
        /// <param name="config"></param>
        /// <param name="conversionTarget"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        internal HttpRequestMessage BuildRequestMessage(string url, Stream file, FileType fileType,
            ConversionTarget conversionTarget, JObject config = null)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (config == null)
                config = new JObject();

            //Attach the conversion target to the config
            var jsonSerializer = new JsonSerializer();
            var stringEnumConverter = new StringEnumConverter();
            jsonSerializer.Converters.Add(stringEnumConverter);
            config["conversion_target"] = JToken.FromObject(conversionTarget, jsonSerializer);

            //Serialize the fileType and config to a string
            var serializedFileType =
                JsonConvert.SerializeObject(fileType, Formatting.None, stringEnumConverter).Replace("\"", "");
            var serializedConfig = config.ToString(Formatting.None, stringEnumConverter);

            var streamContent = new StreamContent(file);
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(serializedFileType);

            // ReSharper disable once ExceptionNotDocumented
            var content = new MultipartFormDataContent($"{DateTime.UtcNow.Ticks}")
            {
                {new StringContent(serializedConfig), "config"},
                {streamContent, nameof(file)}
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            return httpRequestMessage;
        }
    }
}