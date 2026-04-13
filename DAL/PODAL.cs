using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ERPSystem.DAL
{
    public class PODAL
    {
        private readonly AppDbContext _context;

        public PODAL(AppDbContext context)
        {
            _context = context;
        }

        // ============================
        // MAIN CRUD OPERATIONS
        // ============================

        public async Task<IEnumerable<PO>> GetAll()
        {
            // Includes used to display names instead of IDs in Index page
            return await _context.PurchaseOrders
                .Include(p => p.Customer)
                .Include(p => p.Product)
                .OrderByDescending(p => p.OrderID)
                .ToListAsync();
        }

        public async Task<PO?> GetById(int id)
        {
            return await _context.PurchaseOrders
                .Include(p => p.Customer)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.OrderID == id);
        }

        public async Task Insert(PO model)
        {
            await _context.PurchaseOrders.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PO model)
        {
            _context.PurchaseOrders.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.PurchaseOrders.FindAsync(id);
            if (data != null)
            {
                _context.PurchaseOrders.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        // ============================
        // DROPDOWN / LOOKUP METHODS
        // REQUIRED FOR PO CREATE & EDIT
        // ============================

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers
                .OrderBy(c => c.ContactPerson)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .OrderBy(p => p.ProdName)
                .ToListAsync();
        }

        public async Task<List<Salesperson>> GetSalespersons()
        {
            return await _context.Salesperson
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    

        // ============================
        // AUTO GENERATE PO NUMBER
        // Example: PO001 -> PO002 -> PO003
        // ============================

        public async Task<string> GenerateNextPONumber()
        {
            var lastPO = await _context.PurchaseOrders
                .OrderByDescending(p => p.OrderID)
                .Select(p => p.PONo)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(lastPO))
            {
                return "PO001";
            }

            // Extract numeric part
            var numberPart = lastPO.Substring(2);

            if (!int.TryParse(numberPart, out int lastNumber))
            {
                return "PO001";
            }

            int nextNumber = lastNumber + 1;

            return $"PO{nextNumber:D3}";
        }
    }
}
