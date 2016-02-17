using System.Collections.Generic;

namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The answer units of a source document.
    /// </summary>
    public interface IAnswerUnits
    {
        /// <summary>
        ///     The list of content of the answer unit.
        /// </summary>
        IEnumerable<IContent> Content { get; set; }

        /// <summary>
        ///     The id of the answer unit.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        ///     The title of the answer unit.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     The type of the answer unit.
        /// </summary>
        string Type { get; set; }
    }
}