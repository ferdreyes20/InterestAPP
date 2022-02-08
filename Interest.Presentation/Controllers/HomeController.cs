using Interest.Presentation.Models;
using Interest.Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestService _requestService;
        public HomeController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _requestService.GetRequests();

            return View(requests.OrderByDescending(r => r.Id));
        }
    }
}
