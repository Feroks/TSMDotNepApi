using System;
using System.Net;

namespace TSMDotNetApi.Models
{
    public class TsmFailedException : Exception
    {
        internal TsmFailedException(string message, HttpStatusCode statusCode, string serverResponse, Uri uri) : base(message)
        {
            StatusCode = statusCode;
            ServerResponse = serverResponse;
            Uri = uri;
        }

        public HttpStatusCode StatusCode { get; }
        public string ServerResponse { get; }
        public Uri Uri { get; }
    }
}
