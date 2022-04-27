using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shared.Helpers
{
    /// <summary>
    /// This exception raises because of API calls results like 400 and 404
    /// </summary>
    public class WebApiClientErrorException : Exception
    {
        public string Response { get; }

        public HttpStatusCode StatusCode { get; }

        public WebApiClientErrorException(string message, HttpStatusCode statusCode, string response)
            : base(message)
        {
            Response = response;

            StatusCode = statusCode;
        }
    }
}
