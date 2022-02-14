using Interest.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interest.Presentation.Services
{
    public interface IRequestService
    {
        Task<List<RequestViewModel>> GetRequestList();
        Task<int> AddRequest(decimal value);
        Task<RequestViewModel> GetRequest(int id);
        Task<int> UpdateRequest(RequestViewModel request);
    }
}
