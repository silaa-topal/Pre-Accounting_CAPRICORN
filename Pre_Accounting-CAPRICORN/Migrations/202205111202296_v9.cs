namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceSerialRowNo", c => c.String(nullable: false, maxLength: 6, unicode: false));
            DropColumn("dbo.Invoices", "InvoiceSerialNo");
            DropColumn("dbo.Invoices", "InvoiceRowNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "InvoiceRowNo", c => c.String(nullable: false, maxLength: 6, unicode: false));
            AddColumn("dbo.Invoices", "InvoiceSerialNo", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            DropColumn("dbo.Invoices", "InvoiceSerialRowNo");
        }
    }
}
