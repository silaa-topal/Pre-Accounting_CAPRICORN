namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ACTs",
                c => new
                    {
                        ACTid = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(),
                        Type = c.String(),
                        CustomerName = c.String(),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ACTid)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceSerialNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        InvoiceRowNo = c.String(maxLength: 6, unicode: false),
                        InvoiceDate = c.String(),
                        InvoiceTime = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TaxOffice = c.String(maxLength: 30, unicode: false),
                        CustomerID = c.Int(nullable: false),
                        TotalAmount = c.Double(),
                        Type = c.String(),
                        PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.PersonnelID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.PersonnelID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 30, unicode: false),
                        CustomerCity = c.String(maxLength: 13, unicode: false),
                        CustomerMailAddress = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceItemID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Stock = c.Int(nullable: false),
                        Brand = c.String(),
                        Status = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelID = c.Int(nullable: false, identity: true),
                        PersonnelName = c.String(),
                        Title = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Authority = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelID);
            
            CreateTable(
                "dbo.STs",
                c => new
                    {
                        STid = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.STid)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.STs", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.InvoiceItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.InvoiceItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ACTs", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.STs", new[] { "InvoiceID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.InvoiceItems", new[] { "ProductID" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "PersonnelID" });
            DropIndex("dbo.Invoices", new[] { "CustomerID" });
            DropIndex("dbo.ACTs", new[] { "InvoiceID" });
            DropTable("dbo.STs");
            DropTable("dbo.Personnels");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.ACTs");
        }
    }
}
