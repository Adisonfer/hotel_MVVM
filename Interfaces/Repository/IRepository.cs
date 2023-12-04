using System.Collections.Generic;

namespace Intarfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();

        T GetItem(int id);

        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
