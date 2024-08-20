using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MecaAgenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceService _serviceService;
        private readonly IServiceProduct _serviceProduct;
        private readonly IServiceBranch _serviceBranch;

        public HomeController(ILogger<HomeController> logger, IServiceService serviceService, IServiceProduct serviceProduct, IServiceBranch serviceBranch)
        {
            _logger = logger;
            _serviceService = serviceService;
            _serviceProduct = serviceProduct;
            _serviceBranch = serviceBranch;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Branches = await _serviceBranch.ListAsync("");
            ViewBag.Services = await _serviceService.ListAsync("");
            ViewBag.Products = await _serviceProduct.ListAsync(null, "", "");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
