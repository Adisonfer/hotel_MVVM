using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private IDbRepos db;
        public AdminService(IDbRepos db)
        {
            this.db = db;
        }

        public List<AdminDTO> GetAllAdmins()
        {
            return db.Administrators.GetList().Select(i => new AdminDTO(i)).ToList();
        }
    }
}
