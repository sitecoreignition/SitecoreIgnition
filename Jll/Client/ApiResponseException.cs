using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Client
{
    public class ApiResponseException : ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string ExtraInfo { get; set; }


        public ApiResponseException(HttpStatusCode statusCode, string message, string extraInfo) : this(statusCode, message)
        {
            ExtraInfo = extraInfo;
        }
        public ApiResponseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ReasonPhrase = message;

        }
    }
}
