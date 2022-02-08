using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interest.Presentation.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public IEnumerable<ComputationViewModel> Computations { get; set; }

    }

    public class ComputationViewModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public decimal InterestRate { get; set; }
        public decimal FutureValue { get; set; }
        public int Year { get; set; }
    }
}
