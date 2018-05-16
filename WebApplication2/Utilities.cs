﻿namespace WebApplication2
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    public static class Utilities
    {
        public static HttpResponseMessage ValidateRecordRequest(HttpRequestMessage request, string record)
        {
            // check if record is null or empty
            if (string.IsNullOrWhiteSpace(record))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Empty records are not allowed");
            }

            return null;
        }

        public static string RemoveSpecialCharacters(string line)
        {
            line = new string((from c in line
                               where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                               select c
                               ).ToArray());
            return line;
        }
    }
}