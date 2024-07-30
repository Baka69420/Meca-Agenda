using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class BillController : Controller
    {
        private readonly IServiceBill _serviceBill;

        public BillController(IServiceBill serviceBill)
        {
            _serviceBill = serviceBill;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceBill.ListAsync(null, null, null, null);
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

                var @object = await _serviceBill.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Bill does not exist");
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
