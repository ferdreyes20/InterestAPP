using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequesList
{
    public class GetRequestListModel
    {
        public int Id { get; set; }
        public IEnumerable<GetRequestListModelComputationModel> Computations { get; set; }
    }
}
