using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService : IServiceService
    {
        private IDbRepos db;
        public ServiceService(IDbRepos db)
        {
            this.db = db;
        }
        public ServiceDTO GetService(int id)
        {
            return new ServiceDTO(db.Services.GetItem(id));
        }

        public List<ServiceDTO> GetServices()
        {
            return db.Services.GetList().Select(x => new ServiceDTO(x)).ToList();
        }
    }
}
