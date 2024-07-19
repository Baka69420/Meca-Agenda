using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IServiceBranch _serviceBranch;
        private readonly IServiceBranchSchedule _serviceBranchSchedule;
        private readonly IServiceScheduleException _serviceScheduleException;

        public ScheduleController(IServiceBranch serviceBranch, IServiceBranchSchedule serviceBranchSchedule, IServiceScheduleException serviceScheduleException)
        {
            _serviceBranch = serviceBranch;
            _serviceBranchSchedule = serviceBranchSchedule;
            _serviceScheduleException = serviceScheduleException;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceBranch.ListAsync();
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

                var @object = await _serviceBranch.GetAsync(id.Value);

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> CreateSchedule(int? branchId)
        {
            if (branchId == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            ViewBag.Branch = await _serviceBranch.GetAsync(branchId.Value);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSchedule(BranchScheduleDTO branchScheduleDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceBranchSchedule.AddAsync(branchScheduleDTO);
            return RedirectToAction("Details", new { id = branchScheduleDTO.BranchId });
        }

        [HttpGet]
        public async Task<ActionResult> EditSchedule(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranchSchedule.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Product does not exist");
                }

                ViewBag.Branch = await _serviceBranch.GetAsync(@object.BranchId);

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditSchedule(BranchScheduleDTO branchScheduleDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceBranchSchedule.UpdateAsync(branchScheduleDTO);
            return RedirectToAction("Details", new { id = branchScheduleDTO.BranchId });
        }

        [HttpGet]
        public async Task<ActionResult> DeleteSchedule(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranchSchedule.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Product does not exist");
                }

                ViewBag.Branch = await _serviceBranch.GetAsync(@object.BranchId);

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSchedule(int? id, int? branchId, IFormCollection collection)
        {
            if (id == null || branchId == null)
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

            await _serviceBranchSchedule.DeleteAsync(id.Value);
            return RedirectToAction("Details", new { id = branchId });
        }
    }
}
