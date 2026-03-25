using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class SalespersonService
    {
        private readonly SalespersonDAL _dal;

        public SalespersonService(SalespersonDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Salesperson>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(Salesperson model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(Salesperson model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}

