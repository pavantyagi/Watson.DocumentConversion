﻿using System.IO;
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
        ///     Converts a document to Answer Units.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        IAnswers ConvertDocumentToAnswer(Stream file);

        /// <summary>
        ///     Converts a document to HTML.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        string ConvertDocumentToHtml(Stream file);

        /// <summary>
        ///     Converts a document to Text.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        string ConvertDocumentToText(Stream file);
    }
}