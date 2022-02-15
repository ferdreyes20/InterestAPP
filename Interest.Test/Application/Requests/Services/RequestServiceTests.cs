using Interest.Application.Requests.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Test.Application.Requests.Services
{
    [TestFixture]
    public class RequestServiceTests
    {
        private readonly IRequestService _service;
        decimal Value1 = 1000;
        int expectedComputationCount = 4;

        public RequestServiceTests()
        {
            _service = new RequestService();
        }

        [Test]
        public void TestGetComputationsForValue()
        {
            var computations = _service.GetComputationsForValue(Value1);

            Assert.That(computations, Is.Not.Null);
            Assert.That(computations, Has.Count.EqualTo(expectedComputationCount));
        }
    }
}
