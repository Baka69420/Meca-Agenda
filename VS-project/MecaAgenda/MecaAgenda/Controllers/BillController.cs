using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MecaAgenda.Web.Controllers
{
    public class BillController : Controller
    {
        private readonly IServiceBill _serviceBill;
        private readonly IServiceBranch _serviceBranch;
        private readonly IServiceUser _serviceUser;

        public BillController(IServiceBill serviceBill, IServiceBranch serviceBranch, IServiceUser serviceUser)
        {
            _serviceBill = serviceBill;
            _serviceBranch = serviceBranch;
            _serviceUser = serviceUser;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> IndexAdmin()
        {
            var branchOptions = new List<SelectListItem>();

            if (User.IsInRole("Admin"))
            {
                var branches = await _serviceBranch.ListAsync("");

                branchOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "--- Select a Branch ---" }
                };

                branchOptions.AddRange(branches.Select(item => new SelectListItem
                {
                    Value = item.BranchId.ToString(),
                    Text = item.Name
                }));
            }
            else
            {
                var user = await _serviceUser.GetAsync(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value!));

                branchOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = user.BranchId.ToString(), Text = user.Branch.Name }
                };
            }

            var clients = await _serviceUser.ListAsync("client", "");

            var clientOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Client ---" }
            };

            clientOptions.AddRange(clients.Select(item => new SelectListItem
            {
                Value = item.UserId.ToString(),
                Text = item.Name
            }));

            ViewBag.Branches = branchOptions;
            ViewBag.Clients = clientOptions;

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Index()
        {
            var user = await _serviceUser.GetAsync(int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value!));

            var collection = await _serviceBill.ListAsync(null, user.UserId, null, null);

            return View(collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Bill.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBill.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Bill does not exist.";
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
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetBills(int? idBranch, int? idClient, DateOnly? billStartDate, DateOnly? billEndDate)
        {
            var collection = await _serviceBill.ListAsync(idBranch, idClient, billStartDate, billEndDate);

            return PartialView("_BillTableAdmin", collection);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Bill.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceBill.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Bill does not exist.";
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
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Bill.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceBill.DeleteAsync(id.Value);

            TempData["Message"] = "Bill has been deleted.";

            return View();
        }
    }
}
