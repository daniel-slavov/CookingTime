namespace CookingTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Recipe_RecipeID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeID)
                .Index(t => t.Recipe_RecipeID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Owner_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("dbo.Users", t => t.Owner_Username)
                .Index(t => t.Owner_Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        HashedPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Owner_Username", "dbo.Users");
            DropForeignKey("dbo.Ingredients", "Recipe_RecipeID", "dbo.Recipes");
            DropIndex("dbo.Recipes", new[] { "Owner_Username" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_RecipeID" });
            DropTable("dbo.Users");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
