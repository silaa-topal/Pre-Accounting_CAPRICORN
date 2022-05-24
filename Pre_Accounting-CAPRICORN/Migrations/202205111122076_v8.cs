namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.InvoiceItems", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceItems", "Status");
            DropColumn("dbo.Invoices", "Status");
        }
    }
}
