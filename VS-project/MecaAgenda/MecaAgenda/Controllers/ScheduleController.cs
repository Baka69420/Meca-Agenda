using MecaAgenda.Application.DTOs;
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
    }
}
