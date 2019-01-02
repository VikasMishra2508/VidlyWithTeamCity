namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Category_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Category_Id");
            AddForeignKey("dbo.Customers", "Category_Id", "dbo.CustomerCategories", "Id");
            Sql("INSERT INTO MovieCategories(Name) values ('Action')");
            Sql("INSERT INTO MovieCategories(Name) values ('Comedy')");
            Sql("INSERT INTO MovieCategories(Name) values ('Romance')");
            Sql("INSERT INTO MovieCategories(Name) values ('Suspense')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Category_Id", "dbo.CustomerCategories");
            DropIndex("dbo.Customers", new[] { "Category_Id" });
            DropColumn("dbo.Customers", "Category_Id");
        }
    }
}
