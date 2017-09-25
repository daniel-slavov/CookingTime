using System.Data.Entity;
using System.Threading.Tasks;

namespace CookingTime.Data.Contracts
{
    public interface ICookingTimeDbContext
    {
        IDbSet<TEntity> DbSet<TEntity>()
            where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void SetAdded<TEntry>(TEntry entity)
            where TEntry : class;

        void SetDeleted<TEntry>(TEntry entity)
            where TEntry : class;

        void SetUpdated<TEntry>(TEntry entity)
            where TEntry : class;
    }
}
