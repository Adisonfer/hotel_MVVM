using DomainModel;

namespace Intarfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<User> Users { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Client> Clients { get; }
        IRepository<Administrator> Administrators { get; }

        void Save();
    }
}
