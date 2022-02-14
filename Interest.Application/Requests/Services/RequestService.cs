using Interest.Domain.Computations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Services
{
    public class RequestService : IRequestService
    {
        public List<Computation> GetComputationsForValue(decimal value)
        {
            var computations = new List<Computation>();

            int maturityYears = 4;
            decimal lowerBoundInterestRate = 0.10M;
            decimal upperBoundInterestRate = 0.50M;
            decimal increamentalRate = 0.20M;

            decimal currentInterestRate = lowerBoundInterestRate;
            decimal currentValue = value;
            int currentYear = 1;
            for (int i = 0; i < maturityYears; i++)
            {
                var computation = new Computation();
                computation.Value = currentValue;
                computation.Year = currentYear;
                computation.InterestRate = currentInterestRate;
                computation.FutureValue = currentValue +
                    (currentValue * currentInterestRate);

                computations.Add(computation);

                currentYear = currentYear + 1;
                currentValue = computation.FutureValue;
                decimal newRate = currentInterestRate + increamentalRate;
                if (newRate > upperBoundInterestRate)
                {
                    currentInterestRate = upperBoundInterestRate;
                }
                else
                {
                    currentInterestRate = newRate;
                }
            }

            return computations;
        }
    }
}
