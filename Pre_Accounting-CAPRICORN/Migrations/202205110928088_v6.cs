namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "InvoiceSerialNo", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.Invoices", "InvoiceRowNo", c => c.String(nullable: false, maxLength: 6, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "InvoiceRowNo", c => c.String(maxLength: 6, unicode: false));
            AlterColumn("dbo.Invoices", "InvoiceSerialNo", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
    }
}
