namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "CreatedBy");
        }
    }
}
