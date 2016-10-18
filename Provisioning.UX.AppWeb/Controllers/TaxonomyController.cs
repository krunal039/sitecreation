// ***********************************************************************
// Assembly         : Provisioning.UX.AppWeb
// Author           : kruna
// Created          : 10-18-2016
//
// Last Modified By : kruna
// Last Modified On : 10-18-2016
// ***********************************************************************
// <copyright file="TaxonomyController.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using OfficeDevPnP.Core.WebAPI;
using Provisioning.Common;
using Provisioning.Common.Data.SiteRequests;
using Provisioning.Common.Utilities;
using Provisioning.UX.AppWeb.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Provisioning.UX.AppWeb.Controllers
{
    /// <summary>
    /// Class TaxonomyController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class TaxonomyController : ApiController
    {
        /// <summary>
        /// Registers the specified share point service context.
        /// </summary>
        /// <param name="sharePointServiceContext">The share point service context.</param>
        [HttpPut]
        public void Register(WebAPIContext sharePointServiceContext)
        {
            WebAPIHelper.AddToCache(sharePointServiceContext);
        }

        /// <summary>
        /// Gets the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>HttpResponseMessage.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException">
        /// </exception>
        [Route("api/provisioning/taxonomy/get")]
        [WebAPIContextFilter]
        [HttpGet]
        public HttpResponseMessage Get([FromBody]string value)
        {
            try
            {
                if("" == null) {
                    var _message = string.Format("The site request url {0} does not exist", "");
                    HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.NotFound, _message);
                    throw new HttpResponseException(_response);
                
                }
                else{
                    return Request.CreateResponse<SiteInformation>(HttpStatusCode.OK, "");
                }
               
            }
            catch(HttpResponseException)
            {
                throw;
            }
            catch(JsonException _ex)
            {
                var _message = string.Format("There was an error with the data. Exception {0}", _ex.Message);
                Log.Error("SiteRequestController.GetSiteRequest",
                     "There was an error processing the request. Error Message {0} Error Stack {1}",
                     _ex.Message,
                     _ex);
                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.BadRequest, _message);
                throw new HttpResponseException(_response); 
            }
            catch (Exception _ex)
            {
                var _message = string.Format("There was an error with the data. Exception {0}", _ex.Message);
                Log.Error("SiteRequestController.GetSiteRequest",
                    "There was an error processing your request. Error Message {0} Error Stack {1}",
                    _ex.Message,
                    _ex);
                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.InternalServerError, _message);
                throw new HttpResponseException(_response); 
            }
        }

        /// <summary>
        /// Gets the by group.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>HttpResponseMessage.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException">
        /// </exception>
        /// <exception cref="HttpResponseException"></exception>
        [Route("api/provisioning/taxonomy/getByGroup")]
        [WebAPIContextFilter]
        [HttpGet]
        public HttpResponseMessage GetByGroup([FromBody]string group)
        {
            SiteRequest _data = null;
            try
            {
                _data = JsonConvert.DeserializeObject<SiteRequest>(group);
                var _newRequest = ObjectMapper.ToSiteRequestInformation(_data);

                // Handle the case when the URL is null - ie, were going to generate the URL later 
                if (_newRequest.Url == null)
                {
                    _newRequest.Url = "uri://autogenerate/" + Guid.NewGuid().ToString("N");
                }

                ///Save the Site Request
                ISiteRequestFactory _srf = SiteRequestFactory.GetInstance();
                var _manager = _srf.GetSiteRequestManager();
                
                _manager.CreateNewSiteRequest(_newRequest);
                 return Request.CreateResponse<SiteRequest>(HttpStatusCode.Created, _data);

            }
            catch (JsonSerializationException _ex)
            {
                var _message = string.Format("There was an error with the data. Exception {0}", _ex.Message);
               
                Log.Error("SiteRequestController.CreateSiteRequest",
                     "There was an error creating the new site request. Error Message {0} Error Stack {1}",
                     _ex.Message,
                     _ex);

                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.BadRequest, _message);
                throw new HttpResponseException(_response); 
            }

            catch (Exception _ex)
            {
                var _message = string.Format("There was an error processing the request. Exception {0}", _ex.Message);
                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.InternalServerError, _message);

                Log.Error("SiteRequestController.CreateSiteRequest",
                    "There was an error creating the new site request. Error Message {0} Error Stack {1}",
                    _ex.Message,
                    _ex);
                throw new HttpResponseException(_response); 
            }
        }

        /// <summary>
        /// Gets the by group and set.
        /// </summary>
        /// <param name="ownerEmailAddress">The owner email address.</param>
        /// <returns>HttpResponseMessage.</returns>
        /// <exception cref="System.Web.Http.HttpResponseException">
        /// </exception>
        [Route("api/provisioning/siteRequests/getByGroupAndSet")]
        [WebAPIContextFilter]
        [HttpGet]
        public HttpResponseMessage GetByGroupAndSet([FromBody] string ownerEmailAddress)
        {
            try
            {
                var _user = JsonConvert.DeserializeObject<SiteUser>(ownerEmailAddress);
                ISiteRequestFactory _requestFactory = SiteRequestFactory.GetInstance();
                var _manager = _requestFactory.GetSiteRequestManager();
                var _siteRequests = _manager.GetOwnerRequests(_user.Name);
                return Request.CreateResponse((HttpStatusCode)200, _siteRequests);
            }
            catch (JsonSerializationException _ex)
            {
                var _message = string.Format("There was an error with the data. Exception {0}", _ex.Message);

                Log.Error("SiteRequestController.GetOwnerRequestsByEmail",
                     "There was an error get site requests by email. Error Message {0} Error Stack {1}",
                     _ex.Message,
                     _ex);

                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.BadRequest, _message);
                throw new HttpResponseException(_response); 
            }
            catch(Exception _ex)
            {
                var _message = string.Format("There was an error processing the request. {0}", _ex.Message);
                Log.Error("SiteRequestController.GetOwnerRequestsByEmail", "There was an error processing the request. Exception: {0}", _ex);
                HttpResponseMessage _response = Request.CreateResponse(HttpStatusCode.InternalServerError, _message);
                throw new HttpResponseException(_response); 
            }
        }
    }
}
