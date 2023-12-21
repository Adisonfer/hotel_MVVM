using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IServiceService
    {
        List<ServiceDTO> GetServices();
        ServiceDTO GetService(int id);
    }
}
