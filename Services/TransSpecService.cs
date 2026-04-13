using ERPSystem.DAL;
using ERPSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class TransSpecService
    {
        private readonly TransSpecDataDAL _dal;

        public TransSpecService(TransSpecDataDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<TransSpecDataModel>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }

        public async Task Insert(TransSpecDataModel model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(TransSpecDataModel model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }

        public async Task<string> GetNextSpecId()
        {
            return await _dal.GetNextSpecId();
        }
    }
}
