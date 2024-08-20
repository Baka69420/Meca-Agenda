using MecaAgenda.Application.DTOs;
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
        private readonly IServiceService _serviceService;
        private readonly IServiceBranchSchedule _serviceBranchSchedule;
        private readonly IServiceBill _serviceBill;

        public AppointmentController(IServiceAppointment serviceAppointment, IServiceBranch serviceBranch, IServiceUser serviceUser, IServiceService serviceService, IServiceBranchSchedule serviceBranchSchedule, IServiceBill serviceBill)
        {
            _serviceAppointment = serviceAppointment;
            _serviceBranch = serviceBranch;
            _serviceUser = serviceUser;
            _serviceService = serviceService;
            _serviceBranchSchedule = serviceBranchSchedule;
            _serviceBill = serviceBill;
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
            var collection = await _serviceAppointment.ListAsync(idBranch, idClient, appointmentStartDate, appointmentEndDate);

            return PartialView("_AppointmentTableAdmin", collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Appointment.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Appointment does not exist.";
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
        public async Task<decimal> ServicePrice(int? id)
        {
            if (id == null)
            {
                return 0;
            }

            var @object = await _serviceService.GetAsync(id.Value);

            if (@object == null)
            {
                throw new Exception("Service does not exist");
            }

            return @object.Price;
        }

        [HttpGet]
        public async Task<BranchScheduleDTO?> BranchSchedule(int? id, DateOnly? date)
        {
            if (!id.HasValue || !date.HasValue)
            {
                return null;
            }

            var collection = await _serviceBranchSchedule.ListAsync(id.Value);

            if (collection.Count <= 0)
            {
                throw new Exception("Branch does not have schedule");
            }

            DayOfWeek dayOfWeek = date.Value.DayOfWeek;

            BranchScheduleDTO? result = collection.Where(x => x.DayOfWeek == (byte)dayOfWeek).FirstOrDefault();
            
            return result;
        }

        [HttpGet]
        public async Task<TimeOnly?> ServiceTime(int? id, TimeOnly? time)
        {
            if (!id.HasValue || !time.HasValue)
            {
                return null;
            }

            var @object = await _serviceService.GetAsync(id.Value);

            if (@object == null)
            {
                throw new Exception("Service does not exist");
            }

            TimeOnly timeEnd = time.Value.AddMinutes(@object.EstimatedTime);

            return timeEnd;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdmin()
        {
            var branches = await _serviceBranch.ListAsync("");
            var clients = await _serviceUser.ListAsync("client", "");
            var services = await _serviceService.ListAsync("");

            var branchOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Branch ---" }
            };
            var clientOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Client ---" }
            };
            var serviceOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Service ---" }
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
            serviceOptions.AddRange(services.Select(item => new SelectListItem
            {
                Value = item.ServiceId.ToString(),
                Text = item.Name
            }));

            ViewBag.Branches = branchOptions;
            ViewBag.Clients = clientOptions;
            ViewBag.Services = serviceOptions;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(AppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Appointment couldn't be created.";
                return View();
            }

            int appointmentId = await _serviceAppointment.AddAsync(appointmentDTO);

            TempData["Message"] = "Appointment has been created.";

            return RedirectToAction("Details", new { id = appointmentId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Appointment.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Appointment does not exist.";
                    return RedirectToAction("IndexAdmin");
                }

                var branches = await _serviceBranch.ListAsync("");
                var clients = await _serviceUser.ListAsync("client", "");
                var services = await _serviceService.ListAsync("");

                var branchOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "--- Select a Branch ---" }
                };
                var clientOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "--- Select a Client ---" }
                };
                var serviceOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "--- Select a Service ---" }
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
                serviceOptions.AddRange(services.Select(item => new SelectListItem
                {
                    Value = item.ServiceId.ToString(),
                    Text = item.Name
                }));

                ViewBag.Branches = branchOptions;
                ViewBag.Clients = clientOptions;
                ViewBag.Services = serviceOptions;

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Appointment couldn't be updated.";
                return View();
            }

            appointmentDTO.Status = "Rescheduled";

            await _serviceAppointment.UpdateAsync(appointmentDTO);

            TempData["Message"] = "Appointment has been updated.";

            return RedirectToAction("Details", new { id = appointmentDTO.AppointmentId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Appointment.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Appointment does not exist.";
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
        public async Task<IActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Appointment.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceAppointment.DeleteAsync(id.Value);

            TempData["Message"] = "Appointment has been deleted.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> PrelimilaryInvoice(int? id)
        {
            try
            {
                ViewBag.CurrentDate = DateTime.Now.Date.ToString().Split(" ")[0];

                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Appointment.";
                    return RedirectToAction("Index");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Appointment does not exist.";
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
        public async Task<ActionResult> PrelimilaryInvoice(int? id, IFormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Appointment.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceAppointment.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Appointment does not exist.";
                    return RedirectToAction("IndexAdmin");
                }

                BillDTO billDTO = new BillDTO() 
                {
                    ClientId = @object.ClientId,
                    BranchId = @object.BranchId,
                    Date = DateOnly.Parse(DateTime.Now.ToString().Split(" ")[0]),
                    TotalAmount = @object.Price,
                    PaymentMethod = "Cash",
                    Paid = false
                };

                int billId = await _serviceBill.AddAsync(billDTO);

                @object.BillId = billId;
                @object.Status = "Completed";

                await _serviceAppointment.UpdateAsync(@object);
                
                TempData["Message"] = "Preliminary invoice has been created.";

                return RedirectToAction("Details", "Bill", new { id = billId });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
