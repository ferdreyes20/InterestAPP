using Interest.Domain.Computations;
using NUnit.Framework;

namespace Interest.Test.Interest.Domain
{
    [TestFixture]
    public class ComputationTests
    {
        private readonly Computation _computation;
        private const int Id = 1;
        private const decimal Value = 1000;
        private const decimal InterestRate = 0.10M;
        private const int Year = 1;
        private const decimal FutureValue = 1100;

        public ComputationTests()
        {
            _computation = new Computation();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _computation.Id = Id;

            Assert.That(_computation.Id,
                Is.EqualTo(Id));
        }
        [Test]
        public void TestSetAndGetValue()
        {
            _computation.Value = Value;

            Assert.That(_computation.Value,
                Is.EqualTo(Value));
        }
        [Test]
        public void TestSetAndGetInterestRate()
        {
            _computation.InterestRate = InterestRate;

            Assert.That(_computation.InterestRate,
                Is.EqualTo(InterestRate));
        }
        [Test]
        public void TestSetAndGetYear()
        {
            _computation.Year = Year;

            Assert.That(_computation.Year,
                Is.EqualTo(Year));
        }
        [Test]
        public void TestSetAndGetFutureValue()
        {
            _computation.FutureValue = FutureValue;

            Assert.That(_computation.FutureValue,
                Is.EqualTo(FutureValue));
        }
    }
}
