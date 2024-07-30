using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IServiceAppointment _serviceAppointment;

        public AppointmentController(IServiceAppointment serviceAppointment)
        {
            _serviceAppointment = serviceAppointment;
        }

        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceAppointment.ListAsync();

            return View(collection);
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
