using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace ERPSystem.Controllers
{
    public class GRNController : Controller
    {
        private readonly GRNService _service;

        public GRNController(GRNService service)
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
        public async Task<IActionResult> Create(GRN model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        // FIXED: Add Edit actions
        public async Task<IActionResult> Edit(int id)
        {
            var modelList = await _service.GetAll();
            var model = modelList.FirstOrDefault(g => g.GRNID == id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GRN model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);
            return RedirectToAction("Index");
        }
    }
}
