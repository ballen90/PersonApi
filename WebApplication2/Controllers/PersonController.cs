namespace WebApplication2.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApplication2.BusinessLayer.Interfaces;
    using Models;

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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("gender/{type}")]
        public HttpResponseMessage GetRecordSortedByGender(string order)
        {
            try
            {
                var badRequest = Utilities.ValidateNameRequest(this.Request, order);
                if (badRequest != null)
                {
                    return badRequest;
                }
                var response = this.personBusinessLayer.GetRecordsSortedByName(order);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("birthdate/")]
        public HttpResponseMessage GetRecordSortedByBirthdate(string order)
        {
            try
            {
                var badRequest = Utilities.ValidateNameRequest(this.Request, order);
                if (badRequest != null)
                {
                    return badRequest;
                }
                var response = this.personBusinessLayer.GetRecordsSortedByName(order);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("name/")]
        public HttpResponseMessage GetRecordsSortedByName(string sortOrder)
        {
            try
            {
                var badRequest = Utilities.ValidateNameRequest(this.Request, sortOrder);
                if (badRequest != null)
                {
                    return badRequest;
                }
                var response = this.personBusinessLayer.GetRecordsSortedByName(sortOrder);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("records/{record}")]
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
