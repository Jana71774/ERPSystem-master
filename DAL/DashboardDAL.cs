using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERPSystem.DAL
{
    public class DashboardDAL
    {
        private readonly AppDbContext _context;

        public DashboardDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardModel> GetDashboardData()
        {
            return new DashboardModel
            {
                TotalCustomers = await _context.Customers.CountAsync(),
                TotalProducts = await _context.Products.CountAsync(),
                TotalOrders = await _context.PurchaseOrders.CountAsync(),
                TotalInventory = await _context.Inventory.CountAsync()
            };
        }
    }
}