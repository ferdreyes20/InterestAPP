using Interest.Application.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Interest.API.Request
{
    [ApiController]
    [Route("[Controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRepository<Domain.Requests.Request> _repository;
        public RequestController(IRepository<Domain.Requests.Request> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var res = _repository.All()
                .Select(r => new
                {
                    id = r.Id,
                    computations = r.Computations,
                }).ToList();

            
            return Ok(res);
        }
    }
}
