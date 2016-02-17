using System;
using System.Collections.Generic;
using System.Net.Http;
using Watson.DocumentConversion.RequestBuilders;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Watson.DocumentConversion.Tests.RequestBuilderTests
{
    public class RequestBuilderBaseTests
    {
        private const string ServiceUrl = "https://gateway.watsonplatform.net/personality-insights/api/v2/profile";

        public static IEnumerable<object[]> CreateRequestNullData => new[]
        {
            new object[] {null, null},
            new object[] {HttpMethod.Get, null},
            new object[] {null, ServiceUrl}
        };

        [Fact]
        public void CreateRequest_Equal()
        {
            var requestBuilder = new DocumentConversionRequestBuilder();

            var request = requestBuilder.CreateRequest(HttpMethod.Get, ServiceUrl);

            Assert.NotNull(request);
            Assert.Equal(ServiceUrl, request.RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, request.Method);
        }

        [Theory, MemberData("CreateRequestNullData")]
        public void CreateRequest_WithNullParameters_ThrowsArgumentNullException(HttpMethod httpMethod, string url)
        {
            var requestBuilder = new DocumentConversionRequestBuilder();
            var exception = Record.Exception(() => requestBuilder.CreateRequest(null, null));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}