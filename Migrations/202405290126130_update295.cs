namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update295 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "CustomerId", c => c.String());
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String(nullable: false));
            DropColumn("dbo.tb_Order", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "UserId", c => c.String());
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String());
            AlterColumn("dbo.tb_Order", "CustomerId", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
