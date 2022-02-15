using Interest.Application.Requests.Commands.CreateRequest;
using Interest.Application.Requests.Commands.DeleteRequest;
using Interest.Application.Requests.Commands.UpdateRequest;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Application.Requests.Queries.GetRequestComputations;
using Interest.Application.Requests.Queries.GetRequestDetail;

using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IDeleteRequestCommand _deleteCommand;

        public RequestController (
            IGetRequestDetailQuery detailQuery,
            IGetRequestListQuery listQuery,
            IGetRequestComputationsQuery computationsQuery,
            ICreateRequestCommand createCommand,
            IUpdateRequestCommand updateCommand,
            IDeleteRequestCommand deleteCommand
        )
        {
            _detailQuery = detailQuery;
            _listQuery = listQuery;
            _computationsQuery = computationsQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet("GetRequestList")]
        public ActionResult<IEnumerable<GetRequestListModel>> GetRequestList()
        {
            try
            {
                var res = _listQuery.Execute();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRequest")]
        public ActionResult<GetRequestDetailModel> GetRequest(int id)
        {
            try
            {
                var res = _detailQuery.Execute(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateRequest")]
        public ActionResult<int> CreateRequest(CreateRequestModel model)
        {
            try
            {
                var requestId = _createCommand.Execute(model.Value);
                return Ok(requestId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRequestComputations")]
        public ActionResult<IEnumerable<GetRequestComputationsModel>> ComputeRequest(decimal value)
        {
            try
            {
                var requestComputations = _computationsQuery.Execute(value);
                return Ok(requestComputations);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateRequest")]
        public ActionResult<int> UpdateRequest(UpdateRequestModel request)
        {
            try
            {
                var requestId = _updateCommand.Execute(request);
                return requestId;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("RemoveRequest")]
        public ActionResult<int> RemoveRequest(int id)
        {
            try
            {
                var requestId = _deleteCommand.Execute(id);
                return Ok(requestId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
