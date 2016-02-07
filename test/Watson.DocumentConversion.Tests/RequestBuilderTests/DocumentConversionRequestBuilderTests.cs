using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Watson.DocumentConversion.Enums;
using Watson.DocumentConversion.RequestBuilders;
using Watson.DocumentConversion.Tests.Mocks;
using Xunit;

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

        [Fact]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task BuildRequestMessage_WithNullConfig_Equal()
        {
            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[3384]))
            {
                var fileLength = ms.Length;
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, FileType.Xml, ConversionTarget.Text);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");
                var type = (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "type");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);
                Assert.NotNull(type);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(fileLength, file.Length);
                Assert.Equal("{\"conversion_target\":\"NORMALIZED_TEXT\"}",
                    await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal("text/xhtml+xml", await type.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task BuildRequestMessage_WithAnswerUnitConfig_Equal()
        {
            dynamic config = JObject.Parse(MockConfig.MockAnswerUnitConfig);
            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[3384]))
            {
                var fileLength = ms.Length;
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, FileType.Pdf,
                    ConversionTarget.AnswerUnits, config);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");
                var type = (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "type");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);
                Assert.NotNull(type);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(fileLength, file.Length);
                Assert.Equal(
                    "{\"answer_units\":{\"selector_tags\":[\"h1\",\"h2\",\"h3\",\"h4\",\"h5\",\"h6\"]},\"conversion_target\":\"ANSWER_UNITS\"}",
                    await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal("application/pdf", await type.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task BuildRequestMessage_WithHtmlConfig_Equal()
        {
            dynamic config = JObject.Parse(MockConfig.MockHtmlConfig);
            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[3384]))
            {
                var fileLength = ms.Length;
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, FileType.Pdf, ConversionTarget.Html,
                    config);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");
                var type = (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "type");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);
                Assert.NotNull(type);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(fileLength, file.Length);
                Assert.Equal(
                    "{\"normalize_html\":{\"exclude_tags_completely\":[\"script\",\"sup\"],\"exclude_tags_keep_content\":[\"font\",\"em\",\"span\"],\"keep_content\":{\"xpaths\":[\"//body/div[@id='content']\"]},\"exclude_content\":{\"xpaths\":[\"//*[@id='footer']\",\"//*[@id='navigation']\"]},\"keep_tag_attributes\":[\"*\"]},\"conversion_target\":\"NORMALIZED_HTML\"}",
                    await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal("application/pdf", await type.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task BuildRequestMessage_WithPdfConfig_Equal()
        {
            dynamic config = JObject.Parse(MockConfig.MockPdfConfig);
            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[3384]))
            {
                var fileLength = ms.Length;
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, FileType.Pdf, ConversionTarget.Text,
                    config);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");
                var type = (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "type");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);
                Assert.NotNull(type);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(fileLength, file.Length);
                Assert.Equal(
                    "{\"pdf\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}]}},\"conversion_target\":\"NORMALIZED_TEXT\"}",
                    await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal("application/pdf", await type.ReadAsStringAsync().ConfigureAwait(false));
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task BuildRequestMessage_WithMsWordConfig_Equal()
        {
            dynamic config = JObject.Parse(MockConfig.MockMsWordConfig);
            var requestBuilder = new DocumentConversionRequestBuilder();

            using (var ms = new MemoryStream(new byte[3384]))
            {
                var fileLength = ms.Length;
                var request = requestBuilder.BuildRequestMessage(ServiceUrl, ms, FileType.MsWord, ConversionTarget.Text,
                    config);

                Assert.NotNull(request);
                Assert.Equal(ServiceUrl, request.RequestUri.ToString());
                Assert.Equal(HttpMethod.Post, request.Method);

                var content = (MultipartFormDataContent) request.Content;
                var fileContent =
                    (StreamContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "file");
                var configContent =
                    (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "config");
                var type = (StringContent) content.FirstOrDefault(x => x.Headers.ContentDisposition.Name == "type");

                Assert.NotNull(fileContent);
                Assert.NotNull(configContent);
                Assert.NotNull(type);

                var file = await fileContent.ReadAsByteArrayAsync().ConfigureAwait(false);

                Assert.Equal(fileLength, file.Length);
                Assert.Equal(
                    "{\"word\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}],\"styles\":[{\"level\":1,\"names\":[\"pullout heading\",\"pulloutheading\",\"heading\"]},{\"level\":2,\"names\":[\"subtitle\"]}]}},\"conversion_target\":\"NORMALIZED_TEXT\"}",
                    await configContent.ReadAsStringAsync().ConfigureAwait(false));
                Assert.Equal("application/msword", await type.ReadAsStringAsync().ConfigureAwait(false));
            }
        }
    }
}