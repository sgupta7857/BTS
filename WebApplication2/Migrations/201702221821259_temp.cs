namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductBases", "PhotoContentType");
            DropColumn("dbo.ProductBases", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductBases", "Photo", c => c.Binary());
            AddColumn("dbo.ProductBases", "PhotoContentType", c => c.String());
        }
    }
}
