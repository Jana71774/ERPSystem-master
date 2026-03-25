using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class BOMDAL
    {
        private readonly AppDbContext _context;

        public BOMDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BOM>> GetAll()
        {
            return await _context.BOM.ToListAsync();
        }

        public async Task Insert(BOM model)
        {
            await _context.BOM.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BOM model)
        {
            _context.BOM.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.BOM.FindAsync(id);
            if (data != null)
            {
                _context.BOM.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}