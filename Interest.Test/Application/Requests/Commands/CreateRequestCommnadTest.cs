using Interest.Application.Requests.Commands.CreateRequest;
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
    ///     Integration testing - Database - CreateRequestCommnadTest
    /// </summary>
    [TestFixture]
    public class CreateRequestCommnadTest
    {
        [Test]
        public void TestCreateRequestCommandReturnRequestId()
        {
            // Arrange
            decimal value = 1000;
            var builder = new DbContextOptionsBuilder<InterestDbContext>();
            builder.UseInMemoryDatabase("TestCreateRequestCommand");

            // Act
            using (var dbContext = new InterestDbContext(builder.Options))
            {
                var repo = new RequestRepository(dbContext);
                var service = new RequestService();
                var createCommand = new CreateRequestCommand(repo, service);
                var requestIdFromCommand = createCommand.Execute(value);


                // Assert
                Assert.That(requestIdFromCommand, Is.GreaterThan(0));
            }
        }
    }
}

