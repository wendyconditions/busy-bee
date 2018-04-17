using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestingList.Interfaces;

namespace TestingList.Controllers.Api
{
    [RoutePrefix("api/systemdictionary")]
    public class SystemDictionaryController : ApiController
    {
        readonly ISystemDictionaryService systemDicionaryService;

        public SystemDictionaryController(ISystemDictionaryService systemDicionaryService)
        {
            this.systemDicionaryService = systemDicionaryService;
        }
    }
}