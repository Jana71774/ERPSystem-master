using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class TransSpecDataDAL
    {
        private readonly AppDbContext _context;

        public TransSpecDataDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransSpecDataModel>> GetAll()
        {
            return await _context.Set<TransSpecDataModel>().ToListAsync();
        }

        public async Task Insert(TransSpecDataModel model)
        {
            await _context.Set<TransSpecDataModel>().AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TransSpecDataModel model)
        {
            _context.Set<TransSpecDataModel>().Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Set<TransSpecDataModel>().FindAsync(id);

            if (data != null)
            {
                _context.Set<TransSpecDataModel>().Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}