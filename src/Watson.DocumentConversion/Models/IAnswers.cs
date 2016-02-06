using System;
using System.Collections.Generic;

namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The output of document that is converted into an Answer unit.
    /// </summary>
    public interface IAnswers
    {
        /// <summary>
        ///     The list of answer units generated for the source document.
        /// </summary>
        IEnumerable<IAnswerUnits> AnswerUnits { get; set; }

        /// <summary>
        ///     The id of the source document used to derive the answer.
        /// </summary>
        string SourceDocumentId { get; set; }

        /// <summary>
        ///     The date time when the answer was created.
        /// </summary>
        DateTimeOffset Timestamp { get; set; }
    }
}