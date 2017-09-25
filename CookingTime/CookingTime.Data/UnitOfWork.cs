using System;
using CookingTime.Data.Contracts;
using System.Threading.Tasks;

namespace CookingTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICookingTimeDbContext dbContext;

        public UnitOfWork(ICookingTimeDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
