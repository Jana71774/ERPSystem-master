using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class SpecService
    {
        private readonly SpecDAL _dal;

        public SpecService(SpecDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Spec>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(Spec model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(Spec model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}
