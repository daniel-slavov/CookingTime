using CookingTime.Data.Contracts;
using CookingTime.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data
{
    public class CookingTimeDbContext : IdentityDbContext<User>, ICookingTimeDbContext
    {
        public CookingTimeDbContext()
            : base("CookingTimeDb")
        {
            Database.SetInitializer<CookingTimeDbContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static CookingTimeDbContext Create()
        {
            return new CookingTimeDbContext();
        }

        //public IDbSet<User> Users { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Recipe>().Property()
        }
    }
}
