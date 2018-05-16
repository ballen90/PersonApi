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
        public const string GENDER_MALE = "MALE";
        public const string GENDER_FEMALE = "FEMALE";
        public const string ASCENDING = "ASCENDING";
        public const string DESCENDING = "DESCENDING";


        public static HttpResponseMessage ValidateRecordRequest(HttpRequestMessage request, string record)
        {
            // check if record is null or empty
            if (string.IsNullOrWhiteSpace(record))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Empty records are not allowed");
            }

            return null;
        }

        public static HttpResponseMessage ValidateNameRequest(HttpRequestMessage request, string order)
        {
            // check if order is null or empty
            if (string.IsNullOrWhiteSpace(order))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Sort by order must be entered");
            }

            // remove special characters if present and lower
            order = RemoveSpecialCharacters(order).ToUpper();

            if (order.Equals(ASCENDING) || order.Equals(DESCENDING))
            {
                return null;
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Sort order must be specified as either ascending or descending.");
            }

            
        }

        public static HttpResponseMessage ValidateGenderRequest(HttpRequestMessage request, string gender)
        {
            // check if request is null or empty
            if (string.IsNullOrWhiteSpace(gender))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Gender type must be entered");
            }

            // check if request contains any special characters and remove them and lower the type
            gender = RemoveSpecialCharacters(gender).ToUpper();

            if (gender != GENDER_FEMALE || gender != GENDER_MALE)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Gender type must be either male or female.");
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