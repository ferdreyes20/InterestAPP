using Interest.Application.Interfaces.Persistence;
using Interest.Domain.Requests;
using Interest.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Persistence.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private readonly InterestDbContext _dbContext;
        public RequestRepository(InterestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Request Get(int id)
        {
            return _dbContext.Set<Request>()
                .Include(r => r.Computations)
                .FirstOrDefault(r => r.Id == id);
        }

    }
}
