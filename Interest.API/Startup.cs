using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Domain.Computations;
using Interest.Persistence.Repositories;
using Interest.Persistence.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InterestDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("InterestAPP"))
                    .LogTo(
                        Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        LogLevel.Information);
            });

            services.AddTransient<InterestDbContext>();
            services.AddTransient<IRepository<Domain.Requests.Request>, RequestRepository>();
            services.AddTransient<IGetRequestListQuery, GetRequestListQuery>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Interest.API", Version = "v1" });
            });

            CreateInitialDatabase();
        }

        public void CreateInitialDatabase()
        {
            using (var context = new InterestDbContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), Configuration.GetConnectionString("InterestAPP")).Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var computation = new List<Computation>();
                var req = new Domain.Requests.Request()
                {
                    Computations = new List<Computation>
                    {
                        new Computation { Value = 1000, InterestRate = 0.10M, Year = 1, FutureValue = 1100},
                        new Computation { Value = 1100, InterestRate = 0.30M, Year = 2, FutureValue = 1430 },
                        new Computation { Value = 1430, InterestRate = 0.10M, Year = 3, FutureValue = 2145 },
                        new Computation { Value = 2145, InterestRate = 0.10M, Year = 4, FutureValue = 3217.5M }
                    }
                };

                var requestRep = new RequestRepository(context);
                requestRep.Add(req);
                requestRep.Save();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Interest.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
