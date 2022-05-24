namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ACTs", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.STs", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.STs", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.ACTs", "TotalAmount", c => c.Double());
        }
    }
}
