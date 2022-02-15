using Interest.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.DeleteRequest
{
    public class DeleteRequestCommand : IDeleteRequestCommand
    {
        private readonly IRequestRepository _repo;
        public DeleteRequestCommand(IRequestRepository repo)
        {
            _repo = repo;
        }
        public int Execute(int id)
        {

            var request = _repo.Get(id);
            _repo.Remove(request);
            _repo.Save();

            return request.Id;
        }
    }
}
