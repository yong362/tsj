namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Residence = c.String(),
                        SalesPerson = c.String(),
                        ItemBought = c.String(),
                        MonthBought = c.DateTime(nullable: false),
                        Price = c.String(),
                        Qty = c.Int(nullable: false),
                        Sales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tests");
        }
    }
}
