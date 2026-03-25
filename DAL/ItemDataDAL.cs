using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class ItemDataDAL
    {
        private readonly AppDbContext _context;

        public ItemDataDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemData>> GetAll()
        {
            return await _context.ItemData.ToListAsync();
        }

        public async Task Insert(ItemData model)
        {
            await _context.ItemData.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ItemData model)
        {
            _context.ItemData.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.ItemData.FindAsync(id);
            if (data != null)
            {
                _context.ItemData.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}