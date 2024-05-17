namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "Code", c => c.String(nullable: false));
            AddColumn("dbo.tb_Order", "Email", c => c.String());
            AddColumn("dbo.tb_Order", "UserId", c => c.String());
            AddColumn("dbo.tb_Order", "TypePayment", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Order", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Status");
            DropColumn("dbo.tb_Order", "TypePayment");
            DropColumn("dbo.tb_Order", "UserId");
            DropColumn("dbo.tb_Order", "Email");
            DropColumn("dbo.tb_Order", "Code");
        }
    }
}
