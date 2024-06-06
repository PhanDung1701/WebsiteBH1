namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update46 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ChildComment", "ParentComment_Id", "dbo.tb_ParentComment");
            DropForeignKey("dbo.tb_ParentComment", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_LikeProduct", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ChildComment", new[] { "ParentComment_Id" });
            DropIndex("dbo.tb_ParentComment", new[] { "ProductId" });
            DropIndex("dbo.tb_LikeProduct", new[] { "ProductId" });
            DropTable("dbo.tb_ChildComment");
            DropTable("dbo.tb_ParentComment");
            DropTable("dbo.tb_LikeProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_LikeProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ProductId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ParentComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Text = c.String(maxLength: 250),
                        user_id = c.String(),
                        user_name = c.String(),
                        Comment_Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ChildComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PCommentId = c.Int(nullable: false),
                        Text = c.String(maxLength: 250),
                        user_id = c.String(),
                        user_name = c.String(),
                        Comment_Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Modifiedby = c.String(),
                        ParentComment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_LikeProduct", "ProductId");
            CreateIndex("dbo.tb_ParentComment", "ProductId");
            CreateIndex("dbo.tb_ChildComment", "ParentComment_Id");
            AddForeignKey("dbo.tb_LikeProduct", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_ParentComment", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_ChildComment", "ParentComment_Id", "dbo.tb_ParentComment", "Id");
        }
    }
}
