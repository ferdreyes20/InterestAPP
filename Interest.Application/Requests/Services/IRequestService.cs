using Interest.Domain.Computations;
using System.Collections.Generic;

namespace Interest.Application.Requests.Services
{
    public interface IRequestService
    {
        List<Computation> GetComputationsForValue(decimal value);
    }
}
