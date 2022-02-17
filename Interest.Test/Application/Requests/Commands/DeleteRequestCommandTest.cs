using Interest.Application.Requests.Commands.DeleteRequest;
using Interest.Application.Requests.Services;
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
    ///     Integration testing - Database - DeleteRequestCommandTest
    ///     Uses In-Memory database
    /// </summary>
    [TestFixture]
    public class DeleteRequestCommandTest
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

        [Test]
        public void TestCreateRequestExecuteReturnRequest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<InterestDbContext>();
            builder.UseInMemoryDatabase("TestDeleteRequestCommand");
            int requestId = SeedOneRequest(builder.Options);

            // Act
            using (var dbContext = new InterestDbContext(builder.Options))
            {
                var repo = new RequestRepository(dbContext);
                var service = new RequestService();
                var deleteCommand = new DeleteRequestCommand(repo);
                var deletedRequestId = deleteCommand.Execute(requestId);

                // Get deleted request from in-memory database
                var requestFromRepo = repo.Get(deletedRequestId);

                // Assert
                Assert.That(requestFromRepo, Is.Null);
            }
        }
    }
}
