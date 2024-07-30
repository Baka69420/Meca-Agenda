using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MecaAgenda.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IServiceAppointment _serviceAppointment;
        private readonly IServiceBranch _serviceBranch;
        private readonly IServiceUser _serviceUser;

        public AppointmentController(IServiceAppointment serviceAppointment, IServiceBranch serviceBranch, IServiceUser serviceUser)
        {
            _serviceAppointment = serviceAppointment;
            _serviceBranch = serviceBranch;
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var branches = await _serviceBranch.ListAsync("");
            var clients = await _serviceUser.ListAsync("client", "");

            var branchOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Branch ---" }
            };
            var clientOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Client ---" }
            };

            branchOptions.AddRange(branches.Select(item => new SelectListItem
            {
                Value = item.BranchId.ToString(),
                Text = item.Name
            }));
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
        public async Task<IActionResult> GetAppointments(int? idBranch, int? idClient, DateOnly? appointmentStartDate, DateOnly? appointmentEndDate)
        {
            var collection = await _serviceAppointment.ListAsync(idBranch, idClient, null);

            return PartialView("_AppointmentTableAdmin", collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Appointment does not exist");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
