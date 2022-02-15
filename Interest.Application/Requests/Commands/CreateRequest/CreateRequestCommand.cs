using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Services;
using Interest.Domain.Computations;
using Interest.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommand : ICreateRequestCommand
    {
        private readonly IRequestRepository _repo;
        private readonly IRequestService _service;
        public CreateRequestCommand(
            IRequestRepository RequestRepository,
            IRequestService service
            )
        {
            _repo = RequestRepository;
            _service = service;
        }

        public int Execute(decimal value)
        {
            var request = new Request();
            request.Value = value;
            request.Computations = _service.GetComputationsForValue(value);

            _repo.Add(request);
            _repo.Save();

            return request.Id;
        }
    }
}
