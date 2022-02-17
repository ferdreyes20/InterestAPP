using Interest.Application.Requests.Commands.UpdateRequest;
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
    ///     Integration testing - Database - UpdateRequestCommand
    ///     Uses In-Memory database
    /// </summary>
    [TestFixture]
    public class UpdateRequestCommandTest
    {
        private UpdateRequestModel _model;
        private const int Id = 1;
        private const decimal Value = 1000;
        private const decimal newValue = 1100;

        private int SeedOneRequest(DbContextOptions<InterestDbContext> options)
        {
            using (var dbContext = new InterestDbContext(options))
            {
                var request = new Request
                {
                    Value = Value
                };
                dbContext.Requests.Add(request);
                dbContext.SaveChanges();
                return request.Id;
            }
        }

        [SetUp]
        public void SetUp()
        {
            _model = new UpdateRequestModel
            {
                Id = Id,
                Value = newValue
            };
        }

        [Test]
        public void TestCreateRequestExecuteReturnRequest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<InterestDbContext>();
            builder.UseInMemoryDatabase("TestUpdateRequestCommand");
            int requestId = SeedOneRequest(builder.Options);

            // Act
            using (var dbContext = new InterestDbContext(builder.Options))
            {
                var repo = new RequestRepository(dbContext);
                var service = new RequestService();
                var updateCommand = new UpdateRequestCommand(repo, service);
                var updatedRequestId = updateCommand.Execute(_model);

                // Get updated request from in-memory database
                var requestFromRepo = repo.Get(updatedRequestId);

                // Assert
                Assert.That(requestId, Is.EqualTo(requestFromRepo.Id));
                Assert.That(_model.Value, Is.EqualTo(requestFromRepo.Value));
                Assert.That(requestFromRepo.Computations, Is.Not.Null);
            }
        }
    }
}
