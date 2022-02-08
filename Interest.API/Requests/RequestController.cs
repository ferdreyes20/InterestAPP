using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Queries.GetRequesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Interest.API.Request
{
    [ApiController]
    [Route("[Controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IGetRequestListQuery _listQuery;
        public RequestController(IGetRequestListQuery listQuery)
        {
            _listQuery = listQuery;
        }

        [HttpGet]
        public IEnumerable<GetRequestListModel> Index()
        {
            var res = _listQuery.Execute();

            return Ok(res);
        }
    }
}
