using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private IDbRepos db;
        public ClientService(IDbRepos db)
        {
            this.db = db;
        }

        public ClientDTO CurrentClient { get; set;}

        public List<ClientDTO> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new ClientDTO(i)).ToList();
        }
    }
}