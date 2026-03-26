using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryService _service;

        public InventoryController(InventoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var model = await _service.GetPagedAsync(page, size);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = size;
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await _service.Insert(model);
            }
            catch
            {
                ModelState.AddModelError("", "Error creating record");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inventory model)
        {
            if (id != model.StockID)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await _service.Update(model);
            }
            catch
            {
                ModelState.AddModelError("", "Error updating record");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch
            {
                // Log error
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
