using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace WebApplication2
{
    public static class Utilities
    {
        public static HttpResponseMessage ValidateRecordRequest(HttpRequestMessage request, string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Empty records are not allowed");
            }

            return null;
        }

        public static HttpResponseMessage ValidateNameRequest(HttpRequestMessage request, string order)
        {
            if (string.IsNullOrWhiteSpace(order))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Sort by order must be entered");
            }

            return null;
        }
    }
}