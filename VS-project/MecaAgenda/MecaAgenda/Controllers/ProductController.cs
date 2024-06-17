using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceProduct _serviceProduct;

        public ProductController(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collection = await _serviceProduct.ListAsync();
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

                var @object = await _serviceProduct.GetAsync(id.Value);

                if (@object == null)
                {
                    throw new Exception("Product does not exist");
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
