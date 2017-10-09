namespace CookingTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "Owner_Id" });
            AlterColumn("dbo.Recipes", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recipes", "Owner_Id");
            AddForeignKey("dbo.Recipes", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "Owner_Id" });
            AlterColumn("dbo.Recipes", "Owner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Recipes", "Owner_Id");
            AddForeignKey("dbo.Recipes", "Owner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
