namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class te : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductBases", "ProductDesc", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductBases", "ProductDesc", c => c.String());
        }
    }
}
