namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetsj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "roomName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "roomName");
        }
    }
}
