using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Queries.GetRequestComputations
{
    public class GetRequestComputationsModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
        public decimal InterestRate { get; set; }
        public decimal FutureValue { get; set; }
    }
}
