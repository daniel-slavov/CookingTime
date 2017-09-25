using System.Linq;
using CookingTime.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CookingTime.Data.Migrations
{
    using System.Data.Entity.Migrations;

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
        }
    }
}
