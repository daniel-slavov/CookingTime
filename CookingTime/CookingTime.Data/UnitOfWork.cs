using System;
using System.Data.Entity;
using System.Threading.Tasks;
using CookingTime.Data.Contracts;

namespace CookingTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICookingTimeDbContext dbContext;

        public UnitOfWork(ICookingTimeDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("DbContext cannot be null.");
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}