namespace Pre_Accounting_CAPRICORN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personnels", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Personnels", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personnels", "Password", c => c.String());
            AlterColumn("dbo.Personnels", "Username", c => c.String());
        }
    }
}
