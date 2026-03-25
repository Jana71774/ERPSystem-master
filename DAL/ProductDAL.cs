using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class ProductDAL
    {
        private readonly AppDbContext _context;

        public ProductDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Insert(Product model)
        {
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product model)
        {
            _context.Products.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);
            if (data != null)
            {
                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}