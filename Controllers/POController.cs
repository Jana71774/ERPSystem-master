using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ERPSystem.Controllers
{
    public class POController : Controller
    {
        private readonly POService _service;
        private readonly IWebHostEnvironment _env;

        public POController(POService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // ============================
        // LOAD DROPDOWNS (IMPORTANT)
        // ============================
        private async Task LoadDropdowns()
        {
            ViewBag.Customers = new SelectList(
                await _service.GetCustomers(),
                "CustomerID",
                "ContactPerson"
            );

            ViewBag.Products = new SelectList(
                await _service.GetProducts(),
                "ProductID",
                "ProdName"
            );

            ViewBag.Salespersons = new SelectList(
                await _service.GetSalespersons(),
                "EmpID",
                "Name"
            );
        }

        // ============================
        // INDEX
        // ============================
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // ============================
        // CREATE GET
        // ============================
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();

            var model = new PO
            {
                PONo = await _service.GenerateNextPONumber()
            };

            return View(model);
        }

        // ============================
        // CREATE POST
        // ============================
        [HttpPost]
        public async Task<IActionResult> Create(PO model, IFormFile? AttachmentFile)
        {
            // Handle file upload
            if (AttachmentFile != null && AttachmentFile.Length > 0)
            {
                if (!AttachmentFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("AttachmentFile", "Only PDF files are allowed.");
                    await LoadDropdowns();
                    return View(model);
                }

                var uploadsDir = Path.Combine(_env.WebRootPath, "attachments");
                Directory.CreateDirectory(uploadsDir);

                var uniqueFileName = Guid.NewGuid().ToString() + ".pdf";
                var filePath = Path.Combine(uploadsDir, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AttachmentFile.CopyToAsync(stream);
                }

                model.Attachment = $"/attachments/{uniqueFileName}";
            }

            if (ModelState.IsValid)
            {
                await _service.Insert(model);
                return RedirectToAction("Index");
            }

            await LoadDropdowns();
            return View(model);
        }

        // ============================
        // EDIT GET
        // ============================
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetById(id);

            if (model == null)
                return NotFound();

            await LoadDropdowns();
            return View(model);
        }

        // ============================
        // EDIT POST
        // ============================
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PO model, IFormFile? AttachmentFile)
        {
            if (id != model.OrderID)
                return BadRequest();

            // Handle file upload
            if (AttachmentFile != null && AttachmentFile.Length > 0)
            {
                if (!AttachmentFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("AttachmentFile", "Only PDF files are allowed.");
                    await LoadDropdowns();
                    return View(model);
                }

                var uploadsDir = Path.Combine(_env.WebRootPath, "attachments");
                Directory.CreateDirectory(uploadsDir);

                var uniqueFileName = Guid.NewGuid().ToString() + ".pdf";
                var filePath = Path.Combine(uploadsDir, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AttachmentFile.CopyToAsync(stream);
                }

                model.Attachment = $"/attachments/{uniqueFileName}";
            }

            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction(nameof(Index));
            }

            await LoadDropdowns();
            return View(model);
        }

        // ============================
        // DELETE
        // ============================
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _service.GetById(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
