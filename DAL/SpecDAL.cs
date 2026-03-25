using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class SpecDAL
    {
        private readonly AppDbContext _context;

        public SpecDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Spec>> GetAll()
        {
            return await _context.Spec.ToListAsync();
        }

        public async Task Insert(Spec model)
        {
            await _context.Spec.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Spec model)
        {
            _context.Spec.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Spec.FindAsync(id);
            if (data != null)
            {
                _context.Spec.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}