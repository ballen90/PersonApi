namespace WebApplication2.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApplication2.BusinessLayer.Interfaces;

    /// <summary>
    /// Person Controller
    /// </summary>
    public class PersonController : ApiController
    {
        /// <summary>
        /// IPersonBusinessLayer interface
        /// </summary>
        private readonly IPersonBusinessLayer personBusinessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="personBusinessLayer">The Request</param>
        public PersonController(IPersonBusinessLayer personBusinessLayer)
        {
            this.personBusinessLayer = personBusinessLayer;
        }
        
        /// <summary>
        /// Gets records sorted by gender
        /// </summary>
        /// <returns>Http status code</returns>
        [HttpGet]
        [Route("records/gender/")]
        public HttpResponseMessage GetRecordSortedByGender()
        {
            try
            {
                var response = this.personBusinessLayer.GetRecordSortedByGender();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Gets records sorted by birthdate ascending
        /// </summary>
        /// <returns>Http status code</returns>
        [HttpGet]
        [Route("records/birthdate/")]
        public HttpResponseMessage GetRecordSortedByBirthdate()
        {
            try
            {
                var response = this.personBusinessLayer.GetRecordsSortedByBirthdateAscending();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Gets records sorted by last name
        /// </summary>
        /// <returns>Http status code</returns>
        [HttpGet]
        [Route("records/name/")]
        public HttpResponseMessage GetRecordsSortedByLastName()
        {
            try
            {
                var response = this.personBusinessLayer.GetRecordsSortedByLastNameDescending();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Creates and adds a new record to the .txt file.
        /// </summary>
        /// <param name="request">Text record</param>
        /// <returns>Http status code</returns>
        [HttpPost]
        [Route("records/")]
        public HttpResponseMessage CreateRecord(string record)
        {
            try
            {
                var badRequest = Utilities.ValidateRecordRequest(this.Request, record);

                if (badRequest != null)
                {
                    return badRequest;
                }

                var response = this.personBusinessLayer.CreateRecord(record);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
