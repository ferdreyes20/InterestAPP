using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Services;
using Interest.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommand : IUpdateRequestCommand
    {
        private readonly IRequestRepository _repo;
        private readonly IRequestService _service;
        public UpdateRequestCommand(
            IRequestRepository repo,
            IRequestService service
            )
        {
            _repo = repo;
            _service = service;
        }

        public int Execute(UpdateRequestModel request)
        {
            var repoRequest = _repo.Get(request.Id);
            repoRequest.Value = request.Value;

            var computations = _service.GetComputationsForValue(request.Value);
            for (int i = 0; i < repoRequest.Computations.Count; i++)
            {
                repoRequest.Computations[i].Year = computations[i].Year;
                repoRequest.Computations[i].Value = computations[i].Value;
                repoRequest.Computations[i].InterestRate = computations[i].InterestRate;
                repoRequest.Computations[i].FutureValue = computations[i].FutureValue;
            }

            _repo.Update(repoRequest);
            _repo.Save();

            return repoRequest.Id;
        }
    }
}
