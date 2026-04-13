using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class ItemMasterService
    {
        private readonly ItemMasterDAL _dal;

        public ItemMasterService(ItemMasterDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<ItemMaster>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(ItemMaster model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(ItemMaster model)
        {
            await _dal.Update(model);
        }

public async Task<ItemMaster?> GetById(string itemCode)
        {
            return await _dal.GetById(itemCode);
        }

        public async Task Delete(string itemCode)
        {
            await _dal.Delete(itemCode);
        }
    }
}
