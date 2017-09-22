using System;
using System.Data.Entity;
using CookingTime.Data.Contracts;

namespace CookingTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("DbContext cannot be null.");
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}