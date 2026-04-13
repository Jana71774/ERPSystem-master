using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class InventoryService
    {
        private readonly InventoryDAL _dal;

        public InventoryService(InventoryDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Inventory>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(Inventory model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(Inventory model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }

        public async Task<Inventory?> GetByItemCode(string itemCode)
        {
            return await _dal.GetByItemCode(itemCode);
        }
    }
}
