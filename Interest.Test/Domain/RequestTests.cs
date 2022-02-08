using Interest.Domain.Computations;
using Interest.Domain.Requests;
using NUnit.Framework;
using System.Collections.Generic;

namespace Interest.Test.Interest.Domain
{
    [TestFixture]
    public class RequestTests
    {
        private readonly Request _request;
        private const int Id = 1;

        public RequestTests()
        {
            _request = new Request();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _request.Id = Id;

            Assert.That(_request.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetComputation()
        {
            var computation = new Computation();
            _request.Computations = new List<Computation>
            {
                computation
            };

            Assert.That(_request.Computations,
                Contains.Item(computation));
        }
    }
}
