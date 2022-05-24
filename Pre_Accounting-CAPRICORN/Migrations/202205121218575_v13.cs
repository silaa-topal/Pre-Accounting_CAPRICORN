namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
