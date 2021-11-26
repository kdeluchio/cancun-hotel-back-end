using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CancunHotel.Domain.Utils
{
    public class RoulesException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public RoulesException(string message)
         : base(message)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        public RoulesException(HttpStatusCode statusCode, string message)
          : base(message)
        {
            HttpStatusCode = statusCode;
        }
    }
}
