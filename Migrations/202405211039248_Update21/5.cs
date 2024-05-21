namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update215 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribe", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribe", "Email", c => c.String(nullable: false));
        }
    }
}
