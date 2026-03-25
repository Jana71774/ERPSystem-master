using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class GRNService
    {
        private readonly GRNDAL _dal;

        public GRNService(GRNDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<GRN>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(GRN model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(GRN model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}
