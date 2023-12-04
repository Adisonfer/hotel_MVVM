using DomainModel;

namespace Intarfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<User> Users { get; }
        IRepository<Room> Rooms { get; }

        void Save();
    }
}
