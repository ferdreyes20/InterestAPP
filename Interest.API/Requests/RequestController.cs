using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Commands.CreateRequest;
using Interest.Application.Requests.Commands.UpdateRequest;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Application.Requests.Queries.GetRequestComputations;
using Interest.Application.Requests.Queries.GetRequestDetail;
using Interest.Application.Requests.Services;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Interest.API.Request
{
    [ApiController]
    [Route("[Controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IGetRequestDetailQuery _detailQuery;
        private readonly IGetRequestListQuery _listQuery;
        private readonly IGetRequestComputationsQuery _computationsQuery;

        private readonly ICreateRequestCommand _createCommand;
        private readonly IUpdateRequestCommand _updateCommand;

        public RequestController (
            IGetRequestDetailQuery detailQuery,
            IGetRequestListQuery listQuery,
            IGetRequestComputationsQuery computationsQuery,
            ICreateRequestCommand createCommand,
            IUpdateRequestCommand updateCommand
        )
        {
            _detailQuery = detailQuery;
            _listQuery = listQuery;
            _computationsQuery = computationsQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
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

        [HttpPost("CreateRequest")]
        public int CreateRequest(CreateRequestModel model)
        {
            var requestId = _createCommand.Execute(model.Value);
            return requestId;
        }

        [HttpGet("ComputeRequest")]
        public IEnumerable<GetRequestComputationsModel> ComputeRequest(decimal value)
        {
            var requestComputations = _computationsQuery.Execute(value);
            return requestComputations;
        }

        [HttpPut("UpdateRequest")]
        public int UpdateRequest(UpdateRequestModel request)
        {
            var requestId = _updateCommand.Execute(request);
            return requestId;
        }
    }
}
