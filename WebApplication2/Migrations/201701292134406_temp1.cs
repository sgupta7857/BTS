namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        isShippingAddress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ProductId = c.Int(nullable: false),
                        Address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.ManufacturerID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .Index(t => t.Address_AddressID);
            
            CreateTable(
                "dbo.ProductBases",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        ProductDesc = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewTitle = c.String(),
                        rating = c.Double(nullable: false),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID);
            
            AddColumn("dbo.Products", "Category_CategoryID", c => c.Int());
            AddColumn("dbo.Products", "ManufacturerList_ManufacturerID", c => c.Int());
            AddColumn("dbo.Products", "ReviewList_ReviewID", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "Category_CategoryID");
            CreateIndex("dbo.Products", "ManufacturerList_ManufacturerID");
            CreateIndex("dbo.Products", "ReviewList_ReviewID");
            AddForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Products", "ManufacturerList_ManufacturerID", "dbo.Manufacturers", "ManufacturerID");
            AddForeignKey("dbo.Products", "ReviewList_ReviewID", "dbo.Reviews", "ReviewID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ReviewList_ReviewID", "dbo.Reviews");
            DropForeignKey("dbo.Products", "ManufacturerList_ManufacturerID", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Manufacturers", "Address_AddressID", "dbo.Addresses");
            DropIndex("dbo.Products", new[] { "ReviewList_ReviewID" });
            DropIndex("dbo.Products", new[] { "ManufacturerList_ManufacturerID" });
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropIndex("dbo.Manufacturers", new[] { "Address_AddressID" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropColumn("dbo.Products", "ReviewList_ReviewID");
            DropColumn("dbo.Products", "ManufacturerList_ManufacturerID");
            DropColumn("dbo.Products", "Category_CategoryID");
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductBases");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.Addresses");
        }
    }
}
