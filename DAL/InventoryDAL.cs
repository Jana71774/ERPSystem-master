using ERPSystem.Models;
using ERPSystem.DAL;
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
            return await _context.Inventory
                .AsNoTracking()
                .Select(i => new Inventory
                {
                    StockID = i.StockID,
                    ItemCode = i.ItemCode,
                    AvlQty = i.AvlQty,
                    MinQty = i.MinQty,
                    OrderQty = i.OrderQty,
                    Description = i.Description,
                    LoginID = i.LoginID,
                    LoginName = i.LoginName,
                    CreatedDate = i.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetPagedAsync(int page, int size)
        {
            return await _context.Inventory
                .AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .Select(i => new Inventory
                {
                    StockID = i.StockID,
                    ItemCode = i.ItemCode,
                    AvlQty = i.AvlQty,
                    MinQty = i.MinQty,
                    OrderQty = i.OrderQty,
                    Description = i.Description,
                    LoginID = i.LoginID,
                    LoginName = i.LoginName,
                    CreatedDate = i.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            var item = await _context.Inventory
                .Where(i => i.StockID == id)
                .Select(i => new Inventory
                {
                    StockID = i.StockID,
                    ItemCode = i.ItemCode,
                    AvlQty = i.AvlQty,
                    MinQty = i.MinQty,
                    OrderQty = i.OrderQty,
                    Description = i.Description,
                    LoginID = i.LoginID,
                    LoginName = i.LoginName,
                    CreatedDate = i.CreatedDate
                })
                .FirstOrDefaultAsync();
            return item ?? new Inventory();
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
    }
}
