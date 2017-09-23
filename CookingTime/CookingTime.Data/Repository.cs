using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CookingTime.Data.Contracts;
using System.Data.Entity;
using System.Linq;

namespace CookingTime.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext Context;
        private readonly IDbSet<T> Set;

        public Repository(DbContext dbContext)
        {
            this.Context = dbContext ?? throw new ArgumentNullException("Context cannot be null");
            this.Set = this.Context.Set<T>();
        }

        //protected IDbSet<T> Set { get; set; }

        //protected DbContext Context { get; set; }

        public IQueryable<T> All
        {
            get
            {
                return this.Set;
            }
        }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}