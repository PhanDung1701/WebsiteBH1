namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update245 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Content = c.String(),
                        Rate = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.tb_Order", "CustomerId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Review", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Review", new[] { "ProductId" });
            AlterColumn("dbo.tb_Order", "CustomerName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.tb_Order", "CustomerId");
            DropTable("dbo.tb_Review");
        }
    }
}
