using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interest.Presentation.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<ComputationViewModel> Computations { get; set; }

        public bool IsComputed { get; set; }
        public bool IsUpdated { get; set; }

    }
}
