using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class SpecController : Controller
    {
        private readonly SpecService _service;
        private readonly ItemMasterService _itemMasterService;

        public SpecController(SpecService service, ItemMasterService itemMasterService)
        {
            _service = service;
            _itemMasterService = itemMasterService;
        }

        public async Task<IActionResult> Index(string? itemCode, string? itemName)
        {
            List<Spec> specs;

            if (!string.IsNullOrEmpty(itemCode))
            {
                specs = await _service.GetByItemCode(itemCode);
                ViewBag.ItemCode = itemCode;
                ViewBag.ItemName = itemName;
            }
            else
            {
                specs = await _service.GetAll();
            }

            return View(specs);
        }

        public async Task<IActionResult> Create(string? itemCode)
        {
            if (!string.IsNullOrEmpty(itemCode))
            {
                ViewBag.ItemCode = itemCode;
                var itemMasters = await _itemMasterService.GetAll();
                var item = itemMasters.FirstOrDefault(i => i.ItemCode == itemCode);
                ViewBag.ItemName = item?.ItemName ?? "";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Spec model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.ItemCode) && !string.IsNullOrEmpty(model.SpecId))
            {
                await _service.Insert(model);
                return RedirectToAction("Index");
            }
            // Re-populate ViewBag if invalid
            ViewBag.ItemCode = model.ItemCode;
            ViewBag.ItemName = model.ItemName ?? "";
            return View(model);
        }

        public async Task<IActionResult> Edit(string itemCode, string specId)
        {
            var specs = await _service.GetByItemCode(itemCode);
            var spec = specs.FirstOrDefault(s => s.SpecId == specId);
            if (spec == null) return NotFound();
            ViewBag.ItemCode = itemCode;
            ViewBag.ItemName = spec.ItemName;
            return View(spec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Spec model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.ItemCode = model.ItemCode;
            ViewBag.ItemName = model.ItemName ?? "";
            return View(model);
        }

        public async Task<IActionResult> Delete(string itemCode, string specId)
        {
            await _service.Delete(itemCode, specId);
            return RedirectToAction("Index");
        }
    }
}
