using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace ERPSystem.Controllers
{
    public class SalespersonController : Controller
    {
        private readonly SalespersonService _service;

        public SalespersonController(SalespersonService service)
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
        public async Task<IActionResult> Create(Salesperson model)
        {
            await _service.Insert(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        // FIXED: Add Edit actions
        public async Task<IActionResult> Edit(int id)
        {
            var modelList = await _service.GetAll();
            var model = modelList.FirstOrDefault(s => s.EmpID.ToString() == id.ToString());
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Salesperson model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);
            return RedirectToAction("Index");
        }
    }
}
