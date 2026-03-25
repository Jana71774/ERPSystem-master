using ERPSystem.Models;
using ERPSystem.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class ProductService
    {
        private readonly ProductDAL _dal;

        public ProductService(ProductDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Product>> GetAll()
        {
            var data = await _dal.GetAll();
            return data.ToList();
        }


        public async Task Insert(Product model)
        {
            await _dal.Insert(model);
        }

        public async Task Update(Product model)
        {
            await _dal.Update(model);
        }

        public async Task Delete(int id)
        {
            await _dal.Delete(id);
        }
    }
}
