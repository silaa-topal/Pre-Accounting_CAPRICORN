namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.STs", "ProductName", c => c.String());
            AddColumn("dbo.STs", "Type", c => c.String());
            AddColumn("dbo.STs", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.STs", "Quantity");
            DropColumn("dbo.STs", "Type");
            DropColumn("dbo.STs", "ProductName");
        }
    }
}
