using Interest.Presentation.Models;
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

        public async Task<IActionResult> AddRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(decimal value)
        {
            var requestId = await _requestService.AddRequest(value);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditRequest(int id)
        {
            var request = await _requestService.GetRequest(id);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest([FromForm]RequestViewModel viewModel)
        {
            var request = await _requestService.UpdateRequest(viewModel);
            return View();
        }
    }
}
