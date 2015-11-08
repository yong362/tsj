namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tsjadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "tsj", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "tsj");
        }
    }
}
