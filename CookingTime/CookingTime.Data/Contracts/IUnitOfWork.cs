using System;
using System.Threading.Tasks;

namespace CookingTime.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
