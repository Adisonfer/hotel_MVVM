using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUser(int id);
    }
}
