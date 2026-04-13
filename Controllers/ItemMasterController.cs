using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class ItemMasterController : Controller
    {
        private readonly ItemMasterService _service;

        public ItemMasterController(ItemMasterService service)
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
        public async Task<IActionResult> Create(ItemMaster model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var item = await _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ItemMaster model)
        {
            if (id != model.ItemCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string itemCode)
        {
            await _service.Delete(itemCode);
            return RedirectToAction("Index");
        }
    }
}
