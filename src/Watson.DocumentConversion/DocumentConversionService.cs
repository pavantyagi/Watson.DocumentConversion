using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Watson.Core;
using Watson.DocumentConversion.Enums;
using Watson.DocumentConversion.Models;
using Watson.DocumentConversion.RequestBuilders;

namespace Watson.DocumentConversion
{
    /// <summary>
    ///     The Watson Document Conversion service converts a single HTML, PDF, or Microsoft Word document
    ///     into a normalized HTML, plain text, or a set of JSON-formatted Answer units that can be used with
    ///     other Watson services.
    ///     <para>http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/document-conversion.html</para>
    /// </summary>
    public class DocumentConversionService : WatsonService, IDocumentConversionService
    {
        /// <summary>
        ///     Initializes a new instance of the DocumentConversionService class.
        /// </summary>
        /// <param name="username">The service's username.</param>
        /// <param name="password">The service's password.</param>
        public DocumentConversionService(string username, string password)
            : this(username, password, new HttpClient(), new WatsonSettings())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the DocumentConversionService class.
        /// </summary>
        /// <param name="username">The service's username.</param>
        /// <param name="password">The service's password.</param>
        /// <param name="settings">Common settings for all Watson Services.</param>
        public DocumentConversionService(string username, string password, WatsonSettings settings)
            : this(username, password, new HttpClient(), settings)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the DocumentConversionService class.
        /// </summary>
        /// <param name="username">The service's username.</param>
        /// <param name="password">The service's password.</param>
        /// <param name="httpClient">The class for sending HTTP requests and receiving HTTP responses from the service methods.</param>
        /// <param name="settings">Common settings for all Watson Services.</param>
        internal DocumentConversionService(string username, string password, HttpClient httpClient,
            WatsonSettings settings)
            : base(username, password, httpClient, settings)
        {
            // ReSharper disable once ExceptionNotDocumented
            httpClient.BaseAddress = new Uri(ServiceUrl);
        }

        internal DocumentConversionRequestBuilder RequestBuilder { get; } = new DocumentConversionRequestBuilder();

        /// <summary>
        ///     The Service's Url.
        /// </summary>
        public string ServiceUrl { get; } = "https://gateway.watsonplatform.net/document-conversion/api/";

        /// <summary>
        ///     The Service's Url.
        /// </summary>
        public string Version { get; } = "2015-12-15";

        /// <summary>
        ///     Converts a document to Answer Units.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="WatsonException"></exception>
        /// <returns></returns>
        public async Task<IAnswers> ConvertDocumentToAnswersAsync(Stream file, FileType fileType, JObject config = null)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (
                var request = RequestBuilder.BuildRequestMessage($"v1/convert_document?version={Version}", file,
                    fileType, ConversionTarget.AnswerUnits, config))
            {
                var answers = await SendRequestAsync<Answers>(request).ConfigureAwait(false);
                return answers;
            }
        }

        /// <summary>
        ///     Converts a document to HTML.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="WatsonException"></exception>
        /// <returns></returns>
        public async Task<string> ConvertDocumentToHtmlAsync(Stream file, FileType fileType, JObject config = null)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (
                var request = RequestBuilder.BuildRequestMessage($"v1/convert_document?version={Version}", file,
                    fileType, ConversionTarget.Html, config))
            {
                var answers = await SendRequestAsync(request).ConfigureAwait(false);
                return answers;
            }
        }

        /// <summary>
        ///     Converts a document to Text.
        /// </summary>
        /// <param name="file">The file to convert.</param>
        /// <param name="fileType">The file's type.</param>
        /// <param name="config">
        ///     Advanced configuration options.
        ///     <para>See http://www.ibm.com/smarterplanet/us/en/ibmwatson/developercloud/doc/document-conversion/customizing.shtml</para>
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="WatsonException"></exception>
        /// <returns></returns>
        public async Task<string> ConvertDocumentToTextAsync(Stream file, FileType fileType, JObject config = null)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (
                var request = RequestBuilder.BuildRequestMessage($"v1/convert_document?version={Version}", file,
                    fileType, ConversionTarget.Text, config))
            {
                var answers = await SendRequestAsync(request).ConfigureAwait(false);
                return answers;
            }
        }
    }
}