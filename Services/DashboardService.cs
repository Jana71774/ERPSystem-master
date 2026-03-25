using ERPSystem.DAL;
using ERPSystem.Models;
using System.Threading.Tasks;

namespace ERPSystem.Services
{
    public class DashboardService
    {
        private readonly DashboardDAL _dashboardDAL;

        public DashboardService(DashboardDAL dashboardDAL)
        {
            _dashboardDAL = dashboardDAL;
        }

        public async Task<DashboardModel> GetDashboardData()
        {
            return await _dashboardDAL.GetDashboardData();
        }
    }
}