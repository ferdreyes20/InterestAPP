using Interest.Domain.Requests;
using Interest.Persistence.Repositories;
using Interest.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        ///     Integration testing - Database - RequertRepository.Save()
        ///     RequertRepository
        /// </summary>
        [Test]
        public void TestRequestRepositoryGet()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<InterestDbContext>();
            builder.UseInMemoryDatabase("TestRequestRepositoryGet");
            int requestId = SeedOneRequest(builder.Options);

            // Act
            using (var dbContext = new InterestDbContext(builder.Options))
            {
                var requestRepo = new RequestRepository(dbContext);
                var requestFromRepo = requestRepo.Get(requestId);
                // Assert
                Assert.That(requestId, Is.EqualTo(requestFromRepo.Id));
            }
        }

        private int SeedOneRequest(DbContextOptions<InterestDbContext> options)
        {
            using (var dbContext = new InterestDbContext(options))
            {
                var request = new Request();
                dbContext.Requests.Add(request);
                dbContext.SaveChanges();
                return request.Id;
            }
        }
    }
}