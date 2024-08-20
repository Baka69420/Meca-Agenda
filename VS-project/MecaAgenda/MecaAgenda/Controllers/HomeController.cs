using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MecaAgenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceBranch _serviceBranch;

        public HomeController(ILogger<HomeController> logger, IServiceBranch serviceBranch)
        {
            _logger = logger;
            _serviceBranch = serviceBranch;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Branches = await _serviceBranch.ListAsync("");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
