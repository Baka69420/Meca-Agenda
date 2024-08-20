using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MecaAgenda.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceService.ListAsync("");
            return View(collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Service does not exist");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiceDTO serviceDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceService.AddAsync(serviceDTO);
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Service does not exist");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, ServiceDTO serviceDTO)
        {
            if (id == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            serviceDTO.ServiceId = id.Value;

            await _serviceService.UpdateAsync(serviceDTO);
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Service does not exist");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceService.DeleteAsync(id.Value);
            return RedirectToAction("IndexAdmin");
        }
    }
}
