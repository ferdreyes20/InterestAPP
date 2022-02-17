using Interest.Domain.Requests;
using Interest.Persistence.Repositories;
using Interest.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Test.Application.Requests.Commands
{
    /// <summary>
    ///     Integration testing - Database
    ///     Uses In-Memory database
    /// </summary>
    [TestFixture]
    public class CreateRequestCommnadTest
    {
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

        /// <summary>
        ///     CreateRequestCommnad
        /// </summary>
        [Test]
        public void TestCreateRequestExecuteReturnRequest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<InterestDbContext>();
            builder.UseInMemoryDatabase("GetSamurai");
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
    }
}
