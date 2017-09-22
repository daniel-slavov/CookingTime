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
        public Repository(DbContext dbContext)
        {
            this.Context = dbContext ?? throw new ArgumentNullException("Context cannot be null");
            this.Set = this.Context.Set<T>();
        }

        protected IDbSet<T> Set { get; set; }

        protected DbContext Context { get; set; }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public IQueryable<T> Entities
        {
            get { return this.Set; }
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