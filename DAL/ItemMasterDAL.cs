using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class ItemMasterDAL
    {
        private readonly AppDbContext _context;

        public ItemMasterDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemMaster>> GetAll()
        {
            return await _context.ItemMaster.ToListAsync();
        }

        public async Task Insert(ItemMaster model)
        {
            await _context.ItemMaster.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ItemMaster model)
        {
            _context.ItemMaster.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.ItemMaster.FindAsync(id);
            if (data != null)
            {
                _context.ItemMaster.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}