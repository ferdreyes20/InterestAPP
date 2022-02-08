using Interest.Persistence.Repositories;
using Interest.Persistence.Shared;
using Moq;
using NUnit.Framework;

namespace Interest.Test.Interest.Persistence
{
    [TestFixture]
    public class RequestRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<InterestDbContext>();
            var repo = new RequestRepository(context.Object);
            Assert.That(repo, Is.Not.Null);

        }
    }
}
