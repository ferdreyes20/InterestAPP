using Interest.Application.Interfaces.Persistence;
using Interest.Application.Requests.Commands.CreateRequest;
using Interest.Application.Requests.Commands.DeleteRequest;
using Interest.Application.Requests.Commands.UpdateRequest;
using Interest.Application.Requests.Queries.GetRequesList;
using Interest.Application.Requests.Queries.GetRequestComputations;
using Interest.Application.Requests.Queries.GetRequestDetail;
using Interest.Application.Requests.Services;
using Interest.Domain.Computations;
using Interest.Persistence.Repositories;
using Interest.Persistence.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

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
            // Repositories
            services.AddTransient<IRequestRepository, RequestRepository>();
            // Queries
            services.AddTransient<IGetRequestListQuery, GetRequestListQuery>();
            services.AddTransient<IGetRequestDetailQuery, GetRequestDetailQuery>();
            services.AddTransient<IGetRequestComputationsQuery, GetRequestComputationsQuery>();
            // Commands
            services.AddTransient<ICreateRequestCommand, CreateRequestCommand>();
            services.AddTransient<IUpdateRequestCommand, UpdateRequestCommand>();
            services.AddTransient<IDeleteRequestCommand, DeleteRequestCommand>();
            // Services
            services.AddTransient<IRequestService, RequestService>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                    options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

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
                    Value = 1000,
                    Computations = new List<Computation>
                    {
                        new Computation { Value = 1000, InterestRate = 0.10M, Year = 1, FutureValue = 1100},
                        new Computation { Value = 1100, InterestRate = 0.30M, Year = 2, FutureValue = 1430 },
                        new Computation { Value = 1430, InterestRate = 0.50M, Year = 3, FutureValue = 2145 },
                        new Computation { Value = 2145, InterestRate = 0.50M, Year = 4, FutureValue = 3217.5M }
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

            app.UseCors(options =>
                options.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
