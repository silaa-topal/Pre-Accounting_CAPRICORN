namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "InvoiceSerialRowNo", c => c.String(nullable: false, maxLength: 8, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "InvoiceSerialRowNo", c => c.String(nullable: false, maxLength: 7, unicode: false));
        }
    }
}
