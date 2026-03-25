using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        // ✅ FIXED DELETE
        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        // ✅ FIXED EDIT (GET)
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var product = await _service.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // ✅ EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(Product model)
        {
            await _service.Update(model);
            return RedirectToAction("Index");
        }
    }
}