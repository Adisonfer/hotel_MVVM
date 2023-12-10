using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IAdminService
    {
        List<AdminDTO> GetAllAdmins();
    }
}
