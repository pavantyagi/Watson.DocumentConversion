using System.Collections.Generic;
using Newtonsoft.Json;
using Watson.Core.JsonConverters;

namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The answer units of a source document.
    /// </summary>
    public class AnswerUnits : IAnswerUnits
    {
        /// <summary>
        ///     The list of content of the answer unit.
        /// </summary>
        [JsonConverter(typeof (TypeConverter<IEnumerable<Content>>))]
        public IEnumerable<IContent> Content { get; set; }

        /// <summary>
        ///     The id of the answer unit.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The title of the answer unit.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     The type of the answer unit.
        /// </summary>
        public string Type { get; set; }
    }
}