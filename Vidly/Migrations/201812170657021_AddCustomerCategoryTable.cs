namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            


            Sql("INSERT INTO CustomerCategories values (1,'Yearly')");
            Sql("INSERT INTO CustomerCategories values (2,'Half-Yearly')");
            Sql("INSERT INTO CustomerCategories values (3,'Quaterly')");
            Sql("INSERT INTO CustomerCategories values (4,'Monthly')");
            Sql("INSERT INTO CustomerCategories values (5,'Not Regular')");

        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerCategories");
        }
    }
}
