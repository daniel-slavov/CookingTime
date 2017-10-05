using System.Data.Entity;
using CookingTime.Data.Contracts;
using CookingTime.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CookingTime.Data
{
    public class CookingTimeDbContext : IdentityDbContext<User>, ICookingTimeDbContext
    {
        public CookingTimeDbContext()
            : base("CookingTimeDb", throwIfV1Schema: false)
        {
            Database.SetInitializer<CookingTimeDbContext>(null);

            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public static CookingTimeDbContext Create()
        {
            return new CookingTimeDbContext();
        }

        public DbSet<Recipe> Recipes { get; set; }

        //public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<T> DbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        public void SetAdded<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void SetDeleted<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void SetUpdated<T>(T entity) where T : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
