using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class GRNDAL
    {
        private readonly AppDbContext _context;

        public GRNDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GRN>> GetAll()
        {
            return await _context.GRN.ToListAsync();
        }

        public async Task Insert(GRN model)
        {
            await _context.GRN.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(GRN model)
        {
            _context.GRN.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.GRN.FindAsync(id);
            if (data != null)
            {
                _context.GRN.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}