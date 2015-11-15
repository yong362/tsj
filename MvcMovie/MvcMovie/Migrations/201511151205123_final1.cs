namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.excels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        EquipmentName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        TypeofAssets = c.String(),
                        Barcode = c.String(),
                        Location = c.String(),
                        RoomName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.tests");
        }
        
        public override void Down()
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
            
            DropTable("dbo.excels");
        }
    }
}
