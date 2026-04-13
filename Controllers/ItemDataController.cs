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

        // FIXED: Add Edit actions for string ItemCode PK
        public async Task<IActionResult> Edit(string id)
        {
            var modelList = await _service.GetAll();
            var model = modelList.FirstOrDefault(i => i.ItemCode == id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemData model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SelectForBOM()
        {
            var items = await _service.GetAll();
            return View(items);
        }
    }
}
