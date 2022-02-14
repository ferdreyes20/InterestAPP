using System;
using System.Collections.Generic;

namespace Interest.Application.Requests.Queries.GetRequestComputations
{
    public interface IGetRequestComputationsQuery
    {
        IEnumerable<GetRequestComputationsModel> Execute(decimal value);
    }
}
