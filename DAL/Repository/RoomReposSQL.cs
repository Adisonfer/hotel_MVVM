using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RoomReposSQL : IRepository<Room>
    {
        private DataContext db;
        public RoomReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(Room item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Room GetItem(int id)
        {
            return db.Room.Find(id);
        }

        public List<Room> GetList()
        {
            return db.Room.ToList();
        }

        public void Update(Room item)
        {
            throw new NotImplementedException();
        }
    }
}
