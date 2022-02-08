using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequesList
{
    public interface IGetRequestListQuery
    {
        List<GetRequestListModel> Execute();
    }
}
