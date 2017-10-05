namespace CookingTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_ID", "dbo.Ingredients");
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_ID" });
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_ID" });
            AddColumn("dbo.Recipes", "ImageUrl", c => c.String());
            DropTable("dbo.Ingredients");
            DropTable("dbo.RecipeIngredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_ID = c.Guid(nullable: false),
                        Ingredient_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_ID, t.Ingredient_ID });
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Recipes", "ImageUrl");
            CreateIndex("dbo.RecipeIngredients", "Ingredient_ID");
            CreateIndex("dbo.RecipeIngredients", "Recipe_ID");
            AddForeignKey("dbo.RecipeIngredients", "Ingredient_ID", "dbo.Ingredients", "ID", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "Recipe_ID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
    }
}
