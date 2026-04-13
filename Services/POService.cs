using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ERPSystem.Services
{
    public class POService
    {
        private readonly PODAL _dal;

        public POService(PODAL dal)
        {
            _dal = dal;
        }

        // ============================
        // MAIN CRUD OPERATIONS
        // ============================

        public async Task<List<PO>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }

        public async Task<PO?> GetById(int id)
        {
            return await _dal.GetById(id);
        }

        public async Task Insert(PO model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(PO model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }

        // ============================
        // DROPDOWN / LOOKUP METHODS
        // REQUIRED FOR PO CREATE & EDIT
        // ============================

        public async Task<List<Customer>> GetCustomers()
        {
            var data = await _dal.GetCustomers();
            return data.ToList();
        }

        public async Task<List<Product>> GetProducts()
        {
            var data = await _dal.GetProducts();
            return data.ToList();
        }

        public async Task<List<Salesperson>> GetSalespersons()
        {
            var data = await _dal.GetSalespersons();
            return data.ToList();
        }
        public async Task<string> GenerateNextPONumber()
        {
            return await _dal.GenerateNextPONumber();
        }
    }
}
