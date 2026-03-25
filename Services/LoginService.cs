using ERPSystem.Models;
using ERPSystem.DAL;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class LoginService
    {
        private readonly LoginDAL _dal;

        public LoginService(LoginDAL dal)
        {
            _dal = dal;
        }

        public async Task<Login> ValidateUser(string loginId, string password)
        {
            return await _dal.ValidateUser(loginId, password);
        }
    }
}
