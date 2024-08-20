using Azure.Core;
using MecaAgenda.Application.DTOs;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var collection = await _serviceProduct.ListAsync(null, "", "");
            return View(collection);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Product.";
                    if (User.IsInRole("Admin"))
                        return RedirectToAction("IndexAdmin");
                    else
                        return RedirectToAction("Index");
                }

                var @object = await _serviceProduct.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Product does not exist.";
                    if (User.IsInRole("Admin"))
                        return RedirectToAction("IndexAdmin");
                    else
                        return RedirectToAction("Index");
                }

                return View(@object);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            var categories = await _serviceCategory.ListAsync("");

            var categoryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "--- Select a Category ---" }
            };

            categoryOptions.AddRange(categories.Select(item => new SelectListItem
            {
                Value = item.CategoryId.ToString(),
                Text = item.Name
            }));

            ViewBag.Categories = categoryOptions;

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProducts(int? idCategory)
        {
            var collection = await _serviceProduct.ListAsync(idCategory, "", "");

            return PartialView("_ProductTableAdmin", collection);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            ViewBag.ListCategory = await _serviceCategory.ListAsync("");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Product couldn't be created.";
                return View();
            }

            await _serviceProduct.AddAsync(productDTO);

            TempData["Message"] = "Product has been created successfully.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.ListCategory = await _serviceCategory.ListAsync("");

            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Product.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceProduct.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Product does not exist.";
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, ProductDTO productDTO)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Product.";
                return RedirectToAction("IndexAdmin");
            }

            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                TempData["Message"] = "Product couldn't be updated.";
                return View();
            }

            productDTO.ProductId = id.Value;

            await _serviceProduct.UpdateAsync(productDTO);

            TempData["Message"] = "Product has been updated successfully.";

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Message"] = "Couldn't retrieve Product.";
                    return RedirectToAction("IndexAdmin");
                }

                var @object = await _serviceProduct.GetAsync(id.Value);

                if (@object == null)
                {
                    TempData["Message"] = "Product does not exist.";
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
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                TempData["Message"] = "Couldn't retrieve Product.";
                return RedirectToAction("IndexAdmin");
            }

            await _serviceProduct.DeleteAsync(id.Value);

            TempData["Message"] = "Product has been deleted successfully.";

            return RedirectToAction("IndexAdmin");
        }
    }
}
