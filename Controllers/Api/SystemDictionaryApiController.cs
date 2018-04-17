using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestingList.Domain;
using TestingList.Interfaces;
using TestingList.Models.Responses;

namespace TestingList.Controllers.Api
{
    [RoutePrefix("api/systemdictionary")]

    public class SystemDictionaryApiController : ApiController
    {
        readonly ISystemDictionaryService systemDicionaryService;

        public SystemDictionaryApiController(ISystemDictionaryService systemDicionaryService)
        {
            this.systemDicionaryService = systemDicionaryService;
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ModelState);
            }

            ItemsResponse<SystemDictionaryDomain> Response = new ItemsResponse<SystemDictionaryDomain>();
            Response.Items = systemDicionaryService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }

        // Inserts list type and returns new list Id
        [Route(), HttpPost]
        public HttpResponseMessage Insert(SystemDictionaryDomain model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ModelState);
            }
            else
            {
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = systemDicionaryService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
        }
    }
}