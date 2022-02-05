using Interest.Domain.Common;
using Interest.Domain.Computations;
using System;
using System.Collections.Generic;

namespace Interest.Domain.Requests
{
    public class Request : IEntity
    {
        public int Id { get; set; }

        public List<Computation> Computations { get; set; }
    }
}
