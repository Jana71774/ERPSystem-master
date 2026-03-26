using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class ItemDataController : Controller
    {
        private readonly ItemDataService _service;

        public ItemDataController(ItemDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public async Task<IActionResult> SelectForBOM()
        {
            return View(await _service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemData model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemData = await _service.GetById(id);
            if (itemData == null)
            {
                return NotFound();
            }
            return View(itemData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ItemData model)
        {
            if (id != model.ItemCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Log error if needed
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
