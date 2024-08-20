using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MecaAgenda.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceService.ListAsync("");
            return View(collection);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetServices(string serviceName)
        {
            var collection = await _serviceService.ListAsync(serviceName);

            return PartialView("_ServiceTableAdmin", collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't get Service to display.";
                    if (User.IsInRole("Admin"))
                        return RedirectToAction("IndexAdmin");
                    else
                        return RedirectToAction("Index");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Service does not exist.";
                    if (User.IsInRole("Admin"))
                        return RedirectToAction("IndexAdmin");
                    else
                        return RedirectToAction("Index");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiceDTO serviceDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "There was an error while creating the Service.";
                return View();
            }

            await _serviceService.AddAsync(serviceDTO);

            TempData["Message"] = "Service Created Successfully.";
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't get Service information.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Service does not exist.";
                    return RedirectToAction("IndexAdmin");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, ServiceDTO serviceDTO)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't get Service information.";
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "There was an error while creating the Service.";
                return View();
            }

            serviceDTO.ServiceId = id.Value;

            await _serviceService.UpdateAsync(serviceDTO);

            TempData["Message"] = "Service updated successfully.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't get Service.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceService.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Service does not exist.";
                    return RedirectToAction("IndexAdmin");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't get Service to display.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceService.DeleteAsync(id.Value);

            TempData["Message"] = "Service deleted successfully.";

            return RedirectToAction("IndexAdmin");
        }
    }
}
