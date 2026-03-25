using ERPSystem.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.DAL
{
    public class LoginDAL
    {
        private readonly AppDbContext _context;

        public LoginDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Login> ValidateUser(string loginId, string password)
        {
            var user = await _context.Logins
                .FirstOrDefaultAsync(x => x.LoginId == loginId && x.PasswordHash == password && x.IsActive);
            return user ?? new Login();
        }
    }
}