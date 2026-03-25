using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class CustomerDAL
    {
        private readonly AppDbContext _context;

        public CustomerDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Insert(Customer model)
        {
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer model)
        {
            _context.Customers.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Customers.FindAsync(id);
            if (data != null)
            {
                _context.Customers.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}