using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class CustomerService
    {
        private readonly CustomerDAL _dal;

        public CustomerService(CustomerDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Customer>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(Customer model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(Customer model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}

