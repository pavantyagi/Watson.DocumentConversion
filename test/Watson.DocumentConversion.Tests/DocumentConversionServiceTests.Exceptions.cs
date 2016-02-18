using System;
using System.Threading.Tasks;
using Watson.Core;
using Watson.DocumentConversion.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Watson.DocumentConversion.Tests
{
    public partial class DocumentConversionServiceTests
    {
        [Fact]
        public async Task ConvertDocumentToAnswersAsync_NullFile_ThrowsArgumentNullException()
        {
            var service = new DocumentConversionService("username", "password", new WatsonSettings());

            var exception =
                await
                    Record.ExceptionAsync(
                        async () =>
                            await service.ConvertDocumentToAnswersAsync(null, FileType.Xml).ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task ConvertDocumentToHtmlAsync_NullFile_ThrowsArgumentNullException()
        {
            var service = new DocumentConversionService("username", "password", new WatsonSettings());

            var exception =
                await
                    Record.ExceptionAsync(
                        async () => await service.ConvertDocumentToHtmlAsync(null, FileType.Xml).ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public async Task ConvertDocumentToTextAsync_NullFile_ThrowsArgumentNullException()
        {
            var service = new DocumentConversionService("username", "password", new WatsonSettings());

            var exception =
                await
                    Record.ExceptionAsync(
                        async () => await service.ConvertDocumentToTextAsync(null, FileType.Xml).ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}