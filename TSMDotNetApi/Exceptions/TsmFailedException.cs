using System;
using System.Net;

namespace TSMDotNetApi.Exceptions
{
    /// <summary>
    /// Contains details about failed request
    /// </summary>
    public class TsmFailedException : Exception
    {
        internal TsmFailedException(string message, HttpStatusCode statusCode, string serverResponse, Uri uri) : base(message)
        {
            StatusCode = statusCode;
            ServerResponse = serverResponse;
            Uri = uri;
        }
        /// <summary>
        /// HTTP request status
        /// </summary>
        public HttpStatusCode StatusCode { get; }
        
        /// <summary>
        /// Server response
        /// </summary>
        public string ServerResponse { get; }

        /// <summary>
        /// Request was performed to this URL
        /// </summary>
        public Uri Uri { get; }
    }
}
