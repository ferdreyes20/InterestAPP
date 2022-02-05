using Interest.Domain.Common;
using Interest.Domain.Requests;

namespace Interest.Domain.Computations
{
    public class Computation : IEntity
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int Year { get; set; }
        public decimal InterestRate { get; set; }
        public decimal FutureValue { get; set; }

        public Request Request { get; set; }
        public int RequestId { get; set; }

    }
}
