namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.STs", "RemainingStock", c => c.Int(nullable: false));
            AlterColumn("dbo.STs", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.STs", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.STs", "RemainingStock");
        }
    }
}
