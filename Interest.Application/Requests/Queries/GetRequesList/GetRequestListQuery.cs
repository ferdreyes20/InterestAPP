using Interest.Application.Interfaces.Persistence;
using Interest.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequesList
{
    public class GetRequestListQuery : IGetRequestListQuery
    {
        private readonly IRequestRepository _requestRepository;

        public GetRequestListQuery(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public List<GetRequestListModel> Execute()
        {
            return _requestRepository.All()
                .Select(r => new GetRequestListModel
                {
                    Id = r.Id,
                    Value = r.Value,
                    Computations = r.Computations.Select(c => new GetRequestListModelComputationModel
                    {
                        Id = c.Id,
                        Value = c.Value,
                        Year = c.Year,
                        InterestRate = c.InterestRate,
                        FutureValue = c.FutureValue
                    }).ToList()
                }).ToList();
        }
    }
}
