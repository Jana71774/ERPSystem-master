using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class BOMController : Controller
    {
        private readonly BOMService _service;

        public BOMController(BOMService service)
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
        public async Task<IActionResult> Create(BOM model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return BadRequest();

            var model = await _service.GetById(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        // POST: BOM/Edit

        [HttpPost]
        public async Task<IActionResult> Edit(BOM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);

            return RedirectToAction("Index");
        }
    }
}