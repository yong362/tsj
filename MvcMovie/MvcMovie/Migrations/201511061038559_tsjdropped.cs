namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tsjdropped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assets", "tsj");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "tsj", c => c.String());
        }
    }
}
