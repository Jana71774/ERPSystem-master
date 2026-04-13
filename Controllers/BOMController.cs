using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class BOMController : Controller
    {
        private readonly BOMService _service;
        private readonly ProductService _productService;
        private readonly ItemMasterService _itemMasterService;

        public BOMController(BOMService service, ProductService productService, ItemMasterService itemMasterService)
        {
            _service = service;
            _productService = productService;
            _itemMasterService = itemMasterService;
        }

        public async Task<IActionResult> Index(string? productId)
        {
            var allBOMs = await _service.GetAll();
            var filteredBOMs = allBOMs;

            if (!string.IsNullOrEmpty(productId))
            {
                filteredBOMs = allBOMs.Where(b => b.ProductID == productId).ToList();
                try
                {
                    var product = await _productService.GetById(productId);
                    ViewBag.Product = product;
                }
                catch
                {
                    // Product not found, proceed without header
                }
            }

            return View(filteredBOMs);
        }

        public async Task<IActionResult> Create(string? productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest("Product ID is required");
            }

            var product = await _productService.GetById(productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            ViewBag.Product = product;
            ViewBag.Items = (await _itemMasterService.GetAll())
                .Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = i.ItemCode,
                    Text = $"{i.ItemCode} - {i.ItemName}"
                }).ToList();

            return View(new BOM { ProductID = productId, ModelNo = product.ModelNo ?? string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BOM model)
        {
            if (!ModelState.IsValid)
            {
                // Reload ViewBag for errors
                var product = await _productService.GetById(model.ProductID);
                ViewBag.Product = product;
                ViewBag.Items = (await _itemMasterService.GetAll())
                    .Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = i.ItemCode,
                        Text = $"{i.ItemCode} - {i.ItemName}"
                    }).ToList();
                return View(model);
            }

            await _service.Insert(model);
            return RedirectToAction("Index", new { productId = model.ProductID });
        }

        public async Task<IActionResult> Edit(int id, string? productId)
        {
            var modelList = await _service.GetAll();
            var model = modelList.FirstOrDefault(b => b.BOMID == id);
            if (model == null)
                return NotFound();

            var product = await _productService.GetById(model.ProductID ?? productId ?? string.Empty);
            if (product == null)
                return NotFound("Product not found");

            ViewBag.Product = product;
            ViewBag.Items = (await _itemMasterService.GetAll())
                .Select(i => new SelectListItem
                {
                    Value = i.ItemCode,
                    Text = $"{i.ItemCode} - {i.ItemName}"
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BOM model)
        {
            if (!ModelState.IsValid)
            {
                var product = await _productService.GetById(model.ProductID);
                ViewBag.Product = product;
                ViewBag.Items = (await _itemMasterService.GetAll())
                    .Select(i => new SelectListItem
                    {
                        Value = i.ItemCode,
                        Text = $"{i.ItemCode} - {i.ItemName}"
                    }).ToList();
                return View(model);
            }

            await _service.Update(model);
            return RedirectToAction("Index", new { productId = model.ProductID });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
