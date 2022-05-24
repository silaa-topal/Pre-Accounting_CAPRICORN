namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceItems", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceItems", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "TotalAmount", c => c.Double());
        }
    }
}
