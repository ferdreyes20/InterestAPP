using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Commands.CreateRequest;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Application.Requests.Queries.GetRequestDetail;
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
        private readonly IGetRequestDetailQuery _detailQuery;
        private readonly IGetRequestListQuery _listQuery;
        private readonly ICreateRequestCommand _createCommand;

        public RequestController (
            IGetRequestDetailQuery detailQuery,
            IGetRequestListQuery listQuery,
            ICreateRequestCommand createCommand
        )
        {
            _listQuery = listQuery;
            _createCommand = createCommand;
            _detailQuery = detailQuery;
        }

        [HttpGet("GetRequestList")]
        public IEnumerable<GetRequestListModel> GetRequestList()
        {
            var res = _listQuery.Execute();
            return res;
        }

        [HttpGet("GetRequest")]
        public GetRequestDetailModel GetRequest(int id)
        {
            var res = _detailQuery.Execute(id);
            return res;
        }

        [HttpPost]
        public int CreateRequest(CreateRequestModel model)
        {
            var requestId = _createCommand.Execute(model.Value);
            return requestId;
        }
    }
}
