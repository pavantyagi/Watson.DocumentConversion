using System.Runtime.Serialization;

namespace Watson.DocumentConversion.Enums
{
    /// <summary>
    ///     The output format that the document should be converted to.
    /// </summary>
    public enum ConversionTarget
    {
        /// <summary>
        ///     Html
        /// </summary>
        [EnumMember(Value = "NORMALIZED_HTML")] Html,

        /// <summary>
        ///     Text
        /// </summary>
        [EnumMember(Value = "NORMALIZED_TEXT")] Text,

        /// <summary>
        ///     Answer Units in Json format.
        /// </summary>
        [EnumMember(Value = "ANSWER_UNITS")] AnswerUnits
    }
}