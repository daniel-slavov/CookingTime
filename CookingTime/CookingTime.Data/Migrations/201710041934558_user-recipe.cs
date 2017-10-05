namespace CookingTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrecipe : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
