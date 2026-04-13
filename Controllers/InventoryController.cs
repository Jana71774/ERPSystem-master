using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ERPSystem.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryService _service;
        private readonly ItemDataService _itemDataService;

        public InventoryController(InventoryService service, ItemDataService itemDataService)
        {
            _service = service;
            _itemDataService = itemDataService;
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
        public async Task<IActionResult> Create(Inventory model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        // FIXED: Add Edit actions
        public async Task<IActionResult> Edit(string itemCode)
        {
            var model = await _service.GetByItemCode(itemCode);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Inventory model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemData(string term = "")
        {
            var allItems = await _itemDataService.GetAll();
            var items = string.IsNullOrEmpty(term) 
                ? allItems.Take(50).ToList()  // Limit for perf
                : allItems
                    .Where(i => i.ItemCode.Contains(term) || i.ItemName.Contains(term))
                    .Take(20)
                    .ToList();

            return Json(items.Select(i => new 
            { 
                id = i.ItemCode, 
                text = $"{i.ItemCode} - {i.ItemName}",
                itemName = i.ItemName,
                itemDataValue = i.ItemDataValue ?? ""
            }));
        }
    }
}
