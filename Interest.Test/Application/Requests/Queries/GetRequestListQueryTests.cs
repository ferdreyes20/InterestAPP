
using AutoMoq;
using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Domain.Computations;
using Interest.Domain.Requests;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Interest.Test.Application.Requests.Queries
{
    [TestFixture]
    public class GetRequestListQueryTests
    {
        private GetRequestListQuery _query;
        private AutoMoqer _mocker;
        private List<Request> _requests;
        private Request _request;

        private const int RequestId = 1;
        private const int ComputationId = 1;
        private const decimal Value = 1000;
        private const decimal InterestRate = 0.10M;
        private const int Year = 1;
        private const decimal FutureValue = 1100;

        [SetUp]
        public void SetUp()
        {
            var computation = new Computation
            {
                Id = ComputationId,
                Value = Value,
                InterestRate = InterestRate,
                Year = Year,
                FutureValue = FutureValue
            };

            _request = new Request
            {
                Id = RequestId,
                Computations = new List<Computation>
                {
                    computation
                }
            };

            _requests = new List<Request>
            {
                _request
            };

            _mocker = new AutoMoqer();
            _mocker.GetMock<IRepository<Request>>()
                .Setup(c => c.All())
                .Returns(_requests.AsQueryable());
            _query = _mocker.Create<GetRequestListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfSales()
        {
            var results = _query.Execute();
            var result = results.Single();
            var resultComputation = result.Computations.Single();

            Assert.That(result.Id,
                Is.EqualTo(RequestId));
            Assert.That(resultComputation.Id,
                Is.EqualTo(ComputationId));
            Assert.That(resultComputation.Value,
                Is.EqualTo(Value));
            Assert.That(resultComputation.InterestRate,
                Is.EqualTo(InterestRate));
            Assert.That(resultComputation.FutureValue,
                Is.EqualTo(FutureValue));

        }
    }
}
