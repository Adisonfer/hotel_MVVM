using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IDbRepos db;
        public UserService(IDbRepos db)
        {
            this.db = db;
        }
        public List<UserDTO> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new UserDTO(i)).ToList();
        }

        public UserDTO GetClient(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserDTO GetUser(int id)
        {
            return new UserDTO(db.Users.GetItem(id));
        }
    }
}
