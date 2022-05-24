namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
