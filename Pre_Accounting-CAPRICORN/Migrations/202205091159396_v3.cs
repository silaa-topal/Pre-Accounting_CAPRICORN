namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.STs", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.STs", new[] { "InvoiceID" });
            AddColumn("dbo.STs", "InvoiceItemID", c => c.Int(nullable: false));
            CreateIndex("dbo.STs", "InvoiceItemID");
            AddForeignKey("dbo.STs", "InvoiceItemID", "dbo.InvoiceItems", "InvoiceItemID", cascadeDelete: true);
            DropColumn("dbo.STs", "InvoiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.STs", "InvoiceID", c => c.Int(nullable: false));
            DropForeignKey("dbo.STs", "InvoiceItemID", "dbo.InvoiceItems");
            DropIndex("dbo.STs", new[] { "InvoiceItemID" });
            DropColumn("dbo.STs", "InvoiceItemID");
            CreateIndex("dbo.STs", "InvoiceID");
            AddForeignKey("dbo.STs", "InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
        }
    }
}
