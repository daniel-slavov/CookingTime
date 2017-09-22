using CookingTime.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTime.Data
{
    public class CookingTimeContext : DbContext
    {
        public CookingTimeContext()
            : base("Name=CookingTimeContext")
        {
        }

        public static CookingTimeContext Create()
        {
            return new CookingTimeContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add();
        }
    }
}
