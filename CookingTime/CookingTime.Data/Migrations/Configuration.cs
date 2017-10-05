using System.Linq;
using CookingTime.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using CookingTime.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace CookingTime.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CookingTime.Data.CookingTimeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CookingTimeDbContext context)
        {
            if (!context.Roles.Any(r => r.Name.Equals(Constants.AdministratorRoleName)))
            {
                context.Roles.Add(new IdentityRole(Constants.AdministratorRoleName));
            }

            //List<Ingredient> ingredients = new List<Ingredient>() {
            //    new Ingredient(Guid.NewGuid(), "Eggs"),
            //    new Ingredient(Guid.NewGuid(), "Milk"),
            //    new Ingredient(Guid.NewGuid(), "Meat"),
            //    new Ingredient(Guid.NewGuid(), "Tomato"),
            //    new Ingredient(Guid.NewGuid(), "Rice"),
            //};

            //context.Ingredients.AddRange(ingredients);
        }
    }
}
