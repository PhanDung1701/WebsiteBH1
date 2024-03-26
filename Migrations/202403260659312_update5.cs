namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "IsSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_ProductCategory", "Alias", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_ProductCategory", "Icon", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "Icon");
            DropColumn("dbo.tb_ProductCategory", "Alias");
            DropColumn("dbo.tb_Product", "IsSale");
        }
    }
}
