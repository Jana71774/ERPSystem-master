using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class ItemDataService
    {
        private readonly ItemDataDAL _dal;

        public ItemDataService(ItemDataDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<ItemData>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(ItemData model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(ItemData model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}
