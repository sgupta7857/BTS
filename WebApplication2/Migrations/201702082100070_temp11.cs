namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductBases", "PhotoContentType", c => c.String());
            AddColumn("dbo.ProductBases", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductBases", "Photo");
            DropColumn("dbo.ProductBases", "PhotoContentType");
        }
    }
}
