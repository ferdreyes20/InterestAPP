using Interest.Application.Interfaces.Persistence;
using Interest.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequestDetail
{
    public class GetRequestDetailQuery : IGetRequestDetailQuery
    {
        private readonly IRepository<Request> _repo;
        public GetRequestDetailQuery(IRepository<Request> repo)
        {
            _repo = repo;
        }
        public GetRequestDetailModel Execute(int id)
        {
            var request = _repo.All()
                .Where(r => r.Id == id)
                .Select(r => new GetRequestDetailModel
                {
                    Id = r.Id,
                    Computations = r.Computations.Select(c => new GetRequestDetailModelComputationModel
                    {
                        Id = c.Id,
                        Year = c.Year,
                        Value = c.Value,
                        InterestRate = c.InterestRate,
                        FutureValue = c.FutureValue
                    })
                })
                .Single();
            return request;
        }
    }
}
