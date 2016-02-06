using System.Runtime.Serialization;

namespace Watson.DocumentConversion.Enums
{
    /// <summary>
    ///     The file's type.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        ///     Html file.
        /// </summary>
        [EnumMember(Value = "text/html")] Html,

        /// <summary>
        ///     Xml or XHtml file.
        /// </summary>
        [EnumMember(Value = "text/xhtml+xml")] Xml,

        /// <summary>
        ///     Pdf file.
        /// </summary>
        [EnumMember(Value = "application/pdf")] Pdf,

        /// <summary>
        ///     MS Word file.
        /// </summary>
        [EnumMember(Value = "application/msword")] MsWord
    }
}