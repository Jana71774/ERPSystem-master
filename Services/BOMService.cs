using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class BOMService
    {
        private readonly BOMDAL _dal;

        public BOMService(BOMDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<BOM>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }

        public async Task Insert(BOM model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(BOM model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}
