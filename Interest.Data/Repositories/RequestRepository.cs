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
    public class RequestRepository : Repository<Request>
    {
        public RequestRepository(InterestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
