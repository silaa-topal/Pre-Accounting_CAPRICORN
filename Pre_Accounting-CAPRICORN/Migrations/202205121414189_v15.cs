namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Stock", c => c.Int());
            AlterColumn("dbo.STs", "RemainingStock", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.STs", "RemainingStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Stock", c => c.Int(nullable: false));
        }
    }
}
