using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Watson.Core;
using Watson.DocumentConversion.Enums;
using Watson.DocumentConversion.Tests.Mocks;
using Xunit;

namespace Watson.DocumentConversion.Tests
{
    public partial class DocumentConversionServiceTests
    {
        private const string ServiceUrl =
            "https://gateway.watsonplatform.net/document-conversion/api/v1/convert_document?version=2015-12-15";

        [Fact]
        public async Task ConvertDocumentToAnswersAsync()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockDocumentConversionResponses.MockAnswersResponse)
            };

            mockHttpMessageHandler.AddResponseMessage(ServiceUrl, mockResponse);

            var httpCLient = new HttpClient(mockHttpMessageHandler);

            var service = new DocumentConversionService("username", "password", httpCLient, new WatsonSettings());
            var answers =
                await service.ConvertDocumentToAnswersAsync(new MemoryStream(), FileType.Html).ConfigureAwait(false);

            Assert.NotNull(answers);
        }

        [Fact]
        public async Task ConvertDocumentToHtmlAsync()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockDocumentConversionResponses.MockHtmlResponse)
            };

            mockHttpMessageHandler.AddResponseMessage(ServiceUrl, mockResponse);

            var httpCLient = new HttpClient(mockHttpMessageHandler);

            var service = new DocumentConversionService("username", "password", httpCLient, new WatsonSettings());
            var actual =
                await service.ConvertDocumentToHtmlAsync(new MemoryStream(), FileType.Html).ConfigureAwait(false);

            Assert.Equal(MockDocumentConversionResponses.MockHtmlResponse, actual);
        }

        [Fact]
        public async Task ConvertDocumentToTextAsync()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler();
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(MockDocumentConversionResponses.MockTextResponse)
            };

            mockHttpMessageHandler.AddResponseMessage(ServiceUrl, mockResponse);

            var httpCLient = new HttpClient(mockHttpMessageHandler);

            var service = new DocumentConversionService("username", "password", httpCLient, new WatsonSettings());
            var actual =
                await service.ConvertDocumentToTextAsync(new MemoryStream(), FileType.Html).ConfigureAwait(false);

            Assert.Equal(MockDocumentConversionResponses.MockTextResponse, actual);
        }

        [Fact]
        public void HttpClient_SetByConstructor1_IsValid()
        {
            var expectedUrl = "https://gateway.watsonplatform.net/document-conversion/api/";
            var service = new DocumentConversionService("username", "password");

            Assert.NotNull(service);
            Assert.NotNull(service.HttpClient);
            Assert.NotNull(service.HttpClient.BaseAddress);

            Assert.Equal(expectedUrl, service.ServiceUrl);
            Assert.Equal(expectedUrl, service.HttpClient.BaseAddress.ToString());
        }

        [Fact]
        public void HttpClient_SetByConstructor2_IsValid()
        {
            var expectedUrl = "https://gateway.watsonplatform.net/document-conversion/api/";
            var service = new DocumentConversionService("username", "password", new WatsonSettings());

            Assert.NotNull(service);
            Assert.NotNull(service.HttpClient);
            Assert.NotNull(service.HttpClient.BaseAddress);

            Assert.Equal(expectedUrl, service.ServiceUrl);
            Assert.Equal(expectedUrl, service.HttpClient.BaseAddress.ToString());
        }
    }
}