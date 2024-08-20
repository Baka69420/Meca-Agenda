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
            var collection = await _serviceBranch.ListAsync("");
            return View(collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Schedule.";
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
                TempData["Message"] = "Couldn't retrieve Schedule.";
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
                TempData["Message"] = "There was an error while creating the Schedule.";
                return View();
            }

            await _serviceBranchSchedule.AddAsync(branchScheduleDTO);


            TempData["Message"] = "Schedule created successfully.";
            return RedirectToAction("Details", new { id = branchScheduleDTO.BranchId });
        }

        [HttpGet]
        public async Task<ActionResult> EditSchedule(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Schedule.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranchSchedule.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Schedule doesn't exist.";
                    return RedirectToAction("IndexAdmin");
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
                TempData["Message"] = "There was an error while creating the Schedule.";
                return View();
            }

            await _serviceBranchSchedule.UpdateAsync(branchScheduleDTO);

            TempData["Message"] = "Schedule updated successfully.";

            return RedirectToAction("Details", new { id = branchScheduleDTO.BranchId });
        }

        [HttpGet]
        public async Task<ActionResult> DeleteSchedule(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Schedule.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranchSchedule.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Schedule doesn't exist.";
                    return RedirectToAction("IndexAdmin");
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
                TempData["Message"] = "Couldn't retrieve Schedule.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceBranchSchedule.DeleteAsync(id.Value);

            TempData["Message"] = "Schedule deleted successfully.";

            return RedirectToAction("Details", new { id = branchId });
        }
    }
}
