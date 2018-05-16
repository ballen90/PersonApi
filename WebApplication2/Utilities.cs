namespace WebApplication2
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Static utilities class
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Validates that the record being sent isn't empty.
        /// </summary>
        /// <param name="request">HttpRequestMessage</param>
        /// <param name="record">the string record</param>
        /// <returns>HttpResponseMessage or null</returns>
        public static HttpResponseMessage ValidateRecordRequest(HttpRequestMessage request, string record)
        {
            // check if record is null or empty
            if (string.IsNullOrWhiteSpace(record))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Empty records are not allowed.");
            }

            return null;
        }
    }
}