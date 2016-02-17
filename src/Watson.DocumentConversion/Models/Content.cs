using Newtonsoft.Json;

namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The content of an answer unit.
    /// </summary>
    public class Content : IContent
    {
        /// <summary>
        ///     The media type of the answer unit.
        /// </summary>
        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        /// <summary>
        ///     The text of the answer unit.
        /// </summary>
        public string Text { get; set; }
    }
}