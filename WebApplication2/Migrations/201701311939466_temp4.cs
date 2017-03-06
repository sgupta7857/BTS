namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PhotoContentType", c => c.String());
            AddColumn("dbo.Products", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Photo");
            DropColumn("dbo.Products", "PhotoContentType");
        }
    }
}
