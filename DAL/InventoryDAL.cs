using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class InventoryDAL
    {
        private readonly AppDbContext _context;

        public InventoryDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task Insert(Inventory model)
        {
            await _context.Inventory.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Inventory model)
        {
            _context.Inventory.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Inventory.FindAsync(id);
            if (data != null)
            {
                _context.Inventory.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Inventory?> GetByItemCode(string itemCode)
        {
            return await _context.Inventory.FirstOrDefaultAsync(i => i.ItemCode == itemCode);
        }
    }
}