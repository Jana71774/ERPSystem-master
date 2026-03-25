using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class SalespersonDAL
    {
        private readonly AppDbContext _context;

        public SalespersonDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salesperson>> GetAll()
        {
            return await _context.Salesperson.ToListAsync();
        }

        public async Task Insert(Salesperson model)
        {
            await _context.Salesperson.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Salesperson model)
        {
            _context.Salesperson.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Salesperson.FindAsync(id);
            if (data != null)
            {
                _context.Salesperson.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}