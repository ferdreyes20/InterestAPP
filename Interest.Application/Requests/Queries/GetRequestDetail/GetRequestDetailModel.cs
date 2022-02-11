using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequestDetail
{
    public class GetRequestDetailModel
    {
        public int Id { get; set; }
        public IEnumerable<GetRequestDetailModelComputationModel> Computations { get; set; }
    }
}
