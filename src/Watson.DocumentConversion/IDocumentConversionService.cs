using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Watson.DocumentConversion.Enums;
using Watson.DocumentConversion.Models;

namespace Watson.DocumentConversion
{
    /// <summary>
    ///     The Watson Document Conversion service converts a single HTML, PDF, or Microsoft Word document
    ///     into a normalized HTML, plain text, or a set of JSON-formatted Answer units that can be used with
    ///     other Watson services.
    ///     <para>http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/document-conversion.html</para>
    /// </summary>
    public interface IDocumentConversionService
    {
        /// <summary>
        ///     The Service's Url.
        /// </summary>
        string ServiceUrl { get; }

        /// <summary>
        ///     The Api's version.
        /// </summary>
        string Version { get; }

        /// <summary>
        ///     Converts a document to Answer Units.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <returns></returns>
        Task<IAnswers> ConvertDocumentToAnswersAsync(Stream file, FileType fileType, JObject config = null);

        /// <summary>
        ///     Converts a document to HTML.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <returns></returns>
        Task<string> ConvertDocumentToHtmlAsync(Stream file, FileType fileType, JObject config = null);

        /// <summary>
        ///     Converts a document to Text.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <returns></returns>
        Task<string> ConvertDocumentToTextAsync(Stream file, FileType fileType, JObject config = null);
    }
}