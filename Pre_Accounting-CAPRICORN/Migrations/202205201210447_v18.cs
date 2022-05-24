namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String());
        }
    }
}
