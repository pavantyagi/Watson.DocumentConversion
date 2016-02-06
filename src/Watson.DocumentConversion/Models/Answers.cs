using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Watson.Core.JsonConverters;

namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The output of document that is converted into an Answer unit.
    /// </summary>
    public class Answers : IAnswers
    {
        /// <summary>
        ///     The list of answer units generated for the source document.
        /// </summary>
        [JsonProperty("answer_units")]
        [JsonConverter(typeof (TypeConverter<IEnumerable<AnswerUnits>>))]
        public IEnumerable<IAnswerUnits> AnswerUnits { get; set; }

        /// <summary>
        ///     The id of the source document used to derive the answer.
        /// </summary>
        [JsonProperty("source_document_id")]
        public string SourceDocumentId { get; set; }

        /// <summary>
        ///     The date time when the answer was created.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
    }
}