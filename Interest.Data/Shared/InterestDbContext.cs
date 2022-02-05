using Interest.Domain.Computations;
using Interest.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Persistence.Shared
{
    public class InterestDbContext : DbContext
    {
        public InterestDbContext()
        {
        }
        public InterestDbContext(DbContextOptions opt)
            : base(opt)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(local);Initial Catalog=InterestAPP;Integrated Security=true");
            }
        }

        public DbSet<Computation> Computations { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
