using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BranchController : Controller
    {
        private readonly IServiceBranch _serviceBranch;

        public BranchController(IServiceBranch serviceBranch)
        {
            _serviceBranch = serviceBranch;
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
                    TempData["Message"] = "Couldn't retrieve Branch information.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranch.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Branch does not exist.";
                    return RedirectToAction("IndexAdmin");
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
        public async Task<ActionResult> Create(BranchDTO branchDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Branch couldn't be created.";
                return View();
            }

            await _serviceBranch.AddAsync(branchDTO);

            TempData["Message"] = "Branch has been created.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Branch information.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranch.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Branch does not exist.";
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, BranchDTO branchDTO)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Branch information.";
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Branch couldn't be updated.";
                return View();
            }

            branchDTO.BranchId = id.Value;

            await _serviceBranch.UpdateAsync(branchDTO);

            TempData["Message"] = "Branch has been updated.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Branch information.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBranch.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Branch does not exist.";
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Branch information.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceBranch.DeleteAsync(id.Value);

            TempData["Message"] = "Branch has been deleted.";

            return RedirectToAction("IndexAdmin");
        }
    }
}
