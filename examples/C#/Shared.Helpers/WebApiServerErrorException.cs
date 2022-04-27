using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Shared.Helpers
{
    /// <summary>
    /// This exception raises because of API calls results like 500 and 503
    /// </summary>
    public class WebApiServerErrorException : Exception
    {
        public string Response { get; }

        public HttpStatusCode StatusCode { get; }

        public WebApiServerErrorException(string message, HttpStatusCode statusCode, string response)
            : base(message)
        {
            Response = response;

            StatusCode = statusCode;
        }
    }
}
