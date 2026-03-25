using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class PODAL
    {
        private readonly AppDbContext _context;

        public PODAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PO>> GetAll()
        {
            return await _context.PurchaseOrders.ToListAsync();
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
    }
}