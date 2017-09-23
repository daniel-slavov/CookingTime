using System.Linq;

namespace CookingTime.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}