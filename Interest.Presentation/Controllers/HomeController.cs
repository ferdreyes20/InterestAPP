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

        public async Task<IActionResult> Index(int id = 0, bool isDeleted = false)
        {
            ViewBag.Id = id;
            ViewBag.isDeleted = isDeleted;

            var requests = await _requestService.GetRequestList();
            return View(requests.OrderByDescending(r => r.Id));
        }
    }
}
