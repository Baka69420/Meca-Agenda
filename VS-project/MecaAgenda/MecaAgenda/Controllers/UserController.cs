using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceUser.ListAsync();
            return View(collection);
        }
    }
}
