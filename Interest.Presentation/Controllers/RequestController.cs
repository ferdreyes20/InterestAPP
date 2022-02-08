using Interest.Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interest.Presentation.Controllers
{
    public class RequestController : Controller
    {

        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public IActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(decimal value)
        {
            var requestId = await _requestService.AddRequest(value);

            return RedirectToAction("Index", "Home");
        }
    }
}
