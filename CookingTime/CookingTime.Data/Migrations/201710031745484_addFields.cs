namespace CookingTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.Recipes", "IsDeleted");
            DropColumn("dbo.Recipes", "CreatedOn");
        }
    }
}
