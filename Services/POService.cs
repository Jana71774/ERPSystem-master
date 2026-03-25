using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class POService
    {
        private readonly PODAL _dal;

        public POService(PODAL dal)
        {
            _dal = dal;
        }

        public async Task<List<PO>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
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
    }
}
