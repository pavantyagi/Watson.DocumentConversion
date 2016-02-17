namespace Watson.DocumentConversion.Models
{
    /// <summary>
    ///     The content of an answer unit.
    /// </summary>
    public interface IContent
    {
        /// <summary>
        ///     The media type of the answer unit.
        /// </summary>
        string MediaType { get; set; }

        /// <summary>
        ///     The text of the answer unit.
        /// </summary>
        string Text { get; set; }
    }
}