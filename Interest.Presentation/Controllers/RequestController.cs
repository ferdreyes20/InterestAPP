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
            try
            {
                var requestId = await _requestService.AddRequest(value);

                return RedirectToAction("ViewRequest", new { id = requestId, isUpdated = true });
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Error");
            }
        }

        public async Task<IActionResult> EditRequest(int id)
        {
            try
            {
                var request = await _requestService.GetRequest(id);
                return View(request);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest([FromForm]RequestViewModel viewModel)
        {
            try
            {
                if (viewModel.IsComputed)
                {
                    var requestId = await _requestService.UpdateRequest(viewModel);
                    return RedirectToAction("ViewRequest", new { id = requestId, isUpdated = true });
                }

                var computations = await _requestService.GetRequestComputaions(viewModel.Value);
                viewModel.Computations = computations;

                viewModel.IsComputed = true;
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public async Task<IActionResult> ViewRequest(int id, bool isUpdated = false)
        {
            try
            {
                var request = await _requestService.GetRequest(id);
                request.IsUpdated = isUpdated;
                return View(request);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public async Task<IActionResult> DeleteRequest(int id)
        {
            try
            {
                var requestId = await _requestService.DeleteRequest(id);
                return RedirectToAction("Index", "Home", new { id = 1, isDeleted = true });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
