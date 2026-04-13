using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

namespace ERPSystem.Controllers
{
    public class TransSpecController : Controller
    {
        private readonly TransSpecService _service;
        private readonly ItemMasterService _itemService;

        public TransSpecController(TransSpecService service, ItemMasterService itemService)
        {
            _service = service;
            _itemService = itemService;
        }

        // ===================== INDEX =====================
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        // ===================== CREATE (GET) =====================
        public async Task<IActionResult> Create(string? stockId, string? itemcode)
        {
            var model = new TransSpecDataModel();

            if (!string.IsNullOrEmpty(stockId))
                model.StockID = int.Parse(stockId);

            if (!string.IsNullOrEmpty(itemcode))
                model.Itemcode = itemcode;

            // Auto next Spec ID
            model.SpecID = await _service.GetNextSpecId();

            // Load dropdown
            var items = await _itemService.GetAll();

            ViewBag.Items = new SelectList(
                items.Select(i => new
                {
                    i.ItemCode,
                    Display = i.ItemCode + " - " + i.ItemName
                }),
                "ItemCode",
                "Display",
                model.Itemcode
            );

            ViewBag.StockID = stockId;
            ViewBag.Itemcode = itemcode;

            return View(model);
        }

        // ===================== CREATE (POST) =====================
        [HttpPost]
        public async Task<IActionResult> Create(TransSpecDataModel model)
        {
            // Auto-fill ItemName from DB
            if (!string.IsNullOrEmpty(model.Itemcode))
            {
                var item = await _itemService.GetById(model.Itemcode);
                if (item != null)
                    model.ItemName = item.ItemName;
            }

            if (ModelState.IsValid)
            {
                await _service.Insert(model);
                return RedirectToAction("Index");
            }

            // Reload dropdown if validation fails
            var items = await _itemService.GetAll();

            ViewBag.Items = new SelectList(
                items.Select(i => new
                {
                    i.ItemCode,
                    Display = i.ItemCode + " - " + i.ItemName
                }),
                "ItemCode",
                "Display",
                model.Itemcode
            );

            return View(model);
        }

        // ===================== EDIT (GET) =====================
        public async Task<IActionResult> Edit(int stockId, string specId, string itemcode)
        {
            var data = await _service.GetAll();

            var model = data.FirstOrDefault(x =>
                x.StockID == stockId &&
                x.SpecID == specId &&
                x.Itemcode == itemcode);

            if (model == null)
                return NotFound();

            return View(model);
        }

        // ===================== EDIT (POST) =====================
        [HttpPost]
        public async Task<IActionResult> Edit(TransSpecDataModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);
            return RedirectToAction("Index");
        }

        // ===================== DELETE =====================
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        // ===================== AJAX: Get Item Name =====================
        [HttpGet]
        public async Task<IActionResult> GetItemByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return Json(null);

            var item = await _itemService.GetById(code);

            if (item == null)
                return Json(null);

            return Json(new { itemName = item.ItemName });
        }

        // ===================== AJAX: Next Spec ID =====================
        [HttpGet]
        public async Task<IActionResult> GetNextSpecId()
        {
            var nextId = await _service.GetNextSpecId();
            return Json(new { SpecID = nextId });
        }
    }
}