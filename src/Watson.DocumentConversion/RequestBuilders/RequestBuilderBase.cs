﻿using System;
using System.Net.Http;

namespace Watson.DocumentConversion.RequestBuilders
{
    internal abstract class RequestBuilderBase
    {
        /// <exception cref="ArgumentNullException">
        ///     Thrown when a null reference is passed to a method that does not accept it as a
        ///     valid argument.
        /// </exception>
        internal HttpRequestMessage CreateRequest(HttpMethod httpMethod, string url)
        {
            if (httpMethod == null)
                throw new ArgumentNullException(nameof(httpMethod));

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            return new HttpRequestMessage(httpMethod, url);
        }
    }
}