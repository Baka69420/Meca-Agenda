using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MecaAgenda.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceProduct _serviceProduct;
        private readonly IServiceCategory _serviceCategory;

        public ProductController(IServiceProduct serviceProduct, IServiceCategory serviceCategory)
        {
            _serviceProduct = serviceProduct;
            _serviceCategory = serviceCategory;
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

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var collection = await _serviceProduct.ListAsync();
            return View(collection);
        }
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.ListCategory = await _serviceCategory.ListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceProduct.AddAsync(productDTO);
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.ListCategory = await _serviceCategory.ListAsync();

            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, ProductDTO productDTO)
        {
            if (id == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            productDTO.ProductId = id.Value;

            await _serviceProduct.UpdateAsync(productDTO);
            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }

            await _serviceProduct.DeleteAsync(id.Value);
            return RedirectToAction("IndexAdmin");
        }
    }
}
