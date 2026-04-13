using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
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
        public async Task<IActionResult> Create(Customer model)
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
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var customerList = await _service.GetAll();
            var customer = customerList.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(model);
            return RedirectToAction("Index");
        }
    }
}
