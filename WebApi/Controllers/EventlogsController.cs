using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/v1/eventlogs")]
    public class EventlogsController : ApiControllerBase
    {
        //private readonly IDataService _dataService;

        //public EventlogsController(IDataService dataService)
        //{
        //    _dataService = dataService;
        //}

        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(new List<EventlogModel>());
        }
    }
}