﻿using System;
using System.Linq;
using CookingTime.Data.Contracts;

namespace CookingTime.Data
{
    public class EntityFrameworkRepository<T> : IRepository<T>
          where T : class
    {
        private readonly ICookingTimeDbContext dbContext;

        public EntityFrameworkRepository(ICookingTimeDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IQueryable<T> All
        {
            get
            {
                return this.dbContext.DbSet<T>();
            }
        }

        public T GetById(object id)
        {
            return this.dbContext.DbSet<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.dbContext.SetAdded(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.SetDeleted(entity);
        }

        public void Update(T entity)
        {
            this.dbContext.SetUpdated(entity);
        }
    }
}
