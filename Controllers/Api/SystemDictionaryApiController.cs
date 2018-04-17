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
        readonly IListService listService;

        public SystemDictionaryApiController(ISystemDictionaryService systemDicionaryService, IListService listService)
        {
            this.systemDicionaryService = systemDicionaryService;
            this.listService = listService;
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ModelState);
            }

            ItemsResponse<ListTypeModel> Response = new ItemsResponse<ListTypeModel>();
            Response.Items = systemDicionaryService.GetAll();
            
            if(Response.Items != null)
            {
                foreach (var item in Response.Items)
                {
                    item.ToDoList = listService.GetAll().Where(p => p.ListTypeId == item.Id).ToList();
                }
            }
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