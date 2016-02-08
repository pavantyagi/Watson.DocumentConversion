using System.Runtime.Serialization;

namespace Watson.DocumentConversion.Enums
{
    /// <summary>
    ///     The file's type.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        ///     Html file (.html).
        /// </summary>
        [EnumMember(Value = "text/html")] Html,

        /// <summary>
        ///     Xml or XHtml file (.xml).
        /// </summary>
        [EnumMember(Value = "application/xhtml+xml")] Xml,

        /// <summary>
        ///     Pdf file (.pdf).
        /// </summary>
        [EnumMember(Value = "application/pdf")] Pdf,

        /// <summary>
        ///     MS Word file (.doc).
        /// </summary>
        [EnumMember(Value = "application/msword")] MsWordDoc,

        /// <summary>
        ///     MS Word file (.docx).
        /// </summary>
        [EnumMember(Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.document")] MsWordDocx
    }
}