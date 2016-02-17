using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Watson.DocumentConversion.Enums;
using Watson.DocumentConversion.RequestBuilders;
using Watson.DocumentConversion.Tests.Mocks;
using Xunit;

// ReSharper disable PossibleNullReferenceException

// ReSharper disable ExceptionNotDocumented

namespace Watson.DocumentConversion.Tests.RequestBuilderTests
{
    public class DocumentConversionRequestBuilderTests
    {
        private const string ServiceUrl =
            "https://gateway.watsonplatform.net/document-conversion/api/v1/convert_document?version=2015-12-15";

        public static IEnumerable<object[]> BuildRequestMessageExceptionData => new[]
        {
            new object[] {null, null, null, null, null},
            new object[] {ServiceUrl, null, null, null, null},
            new object[] {null, new MemoryStream(), null, null, null}
        };

        public static IEnumerable<object[]> BuildRequestMessageData => new[]
        {
            new object[]
            {
                3384, FileType.Html, ConversionTarget.Text, null, "{\"conversion_target\":\"NORMALIZED_TEXT\"}",
                "text/html"
            },
            new object[]
            {
                54654, FileType.Html, ConversionTarget.Text, MockConfig.MockHtmlConfig,
                "{\"normalize_html\":{\"exclude_tags_completely\":[\"script\",\"sup\"],\"exclude_tags_keep_content\":[\"font\",\"em\",\"span\"],\"keep_content\":{\"xpaths\":[\"//body/div[@id='content']\"]},\"exclude_content\":{\"xpaths\":[\"//*[@id='footer']\",\"//*[@id='navigation']\"]},\"keep_tag_attributes\":[\"*\"]},\"conversion_target\":\"NORMALIZED_TEXT\"}",
                "text/html"
            },
            new object[]
            {
                444, FileType.MsWordDoc, ConversionTarget.Html, MockConfig.MockMsWordConfig,
                "{\"word\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}],\"styles\":[{\"level\":1,\"names\":[\"pullout heading\",\"pulloutheading\",\"heading\"]},{\"level\":2,\"names\":[\"subtitle\"]}]}},\"conversion_target\":\"NORMALIZED_HTML\"}",
                "application/msword"
            },
            new object[]
            {
                4545645, FileType.MsWordDocx, ConversionTarget.Html, MockConfig.MockMsWordConfig,
                "{\"word\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}],\"styles\":[{\"level\":1,\"names\":[\"pullout heading\",\"pulloutheading\",\"heading\"]},{\"level\":2,\"names\":[\"subtitle\"]}]}},\"conversion_target\":\"NORMALIZED_HTML\"}",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            },
            new object[]
            {
                55464564, FileType.Pdf, ConversionTarget.AnswerUnits, MockConfig.MockAnswerUnitConfig,
                "{\"answer_units\":{\"selector_tags\":[\"h1\",\"h2\",\"h3\",\"h4\",\"h5\",\"h6\"]},\"conversion_target\":\"ANSWER_UNITS\"}",
                "application/pdf"
            },
            new object[]
            {
                55464564, FileType.Pdf, ConversionTarget.Text, MockConfig.MockPdfConfig,
                "{\"pdf\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}]}},\"conversion_target\":\"NORMALIZED_TEXT\"}",
                "application/pdf"
            },
            new object[]
            {
                3384, FileType.Xml, ConversionTarget.Text, null, "{\"conversion_target\":\"NORMALIZED_TEXT\"}",
                "application/xhtml+xml"
            }
        };

        [Theory, MemberData("BuildRequestMessageExceptionData")]
        public void BuildRequestMessage_WithNullArguments_ThrowsArgumentNullException(string url, Stream file,
            FileType fileType, ConversionTarget conversionTarget, JObject config)
        {
            var requestBuilder = new DocumentConversionRequestBuilder();

            var exception =
                Record.Exception(() => requestBuilder.BuildRequestMessage(url, file, fileType, conversionTarget, config));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Theory, MemberData("BuildRequestMessageData")]
        public async Task BuildRequestMessage_Equal(int fileLength, FileType fileType, ConversionTarget conversionTarget,
            string mockConfig, string expectedConfig, string expectedMediaType)
        {
            dynamic config = null;
            if (!string.IsNullOrWhiteSpace(mockConfig))
                config = JObject.Parse(mockConfig);

            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[fileLength]))
            {
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, fileType, conversionTarget, config);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(ms.Length, file.Length);
                Assert.Equal(expectedConfig, await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal(expectedMediaType, fileContent.Headers.ContentType.MediaType);
            }
        }
    }
}