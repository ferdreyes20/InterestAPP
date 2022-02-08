using Interest.Application.Interfaces.Persistence;
using Interest.Domain.Computations;
using Interest.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommand : ICreateRequestCommand
    {
        private readonly IRepository<Request> _repo;
        public CreateRequestCommand(IRepository<Request> RequestRepository)
        {
            _repo = RequestRepository;
        }

        public int Execute(decimal value)
        {
            try
            {
                int maturityYears = 4;
                decimal lowerBoundInterestRate = 0.10M;
                decimal upperBoundInterestRate = 0.50M;
                decimal increamentalRate = 0.20M;

                var request = new Request();
                request.Computations = new List<Computation>();

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

                    request.Computations.Add(computation);

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

                _repo.Add(request);
                _repo.Save();

                return request.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
