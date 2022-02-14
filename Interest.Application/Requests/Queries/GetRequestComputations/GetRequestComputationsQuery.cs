using Interest.Application.Requests.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interest.Application.Requests.Queries.GetRequestComputations
{
    public class GetRequestComputationsQuery : IGetRequestComputationsQuery
    {
        private readonly IRequestService _service;
        public GetRequestComputationsQuery(IRequestService service)
        {
            _service = service;
        }
        public IEnumerable<GetRequestComputationsModel> Execute(decimal value)
        {
            var computations = _service.GetComputationsForValue(value).Select(
                    c => new GetRequestComputationsModel
                    {
                        Id = c.Id,
                        Year = c.Year,
                        Value = c.Value,
                        InterestRate = c.InterestRate,
                        FutureValue = c.FutureValue
                    }
                );
            return computations;
        }
    }
}
