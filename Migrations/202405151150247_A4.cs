namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A4 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_ParentComment", t => t.ParentComment_Id)
                .Index(t => t.ParentComment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ParentComment", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.tb_ChildComment", "ParentComment_Id", "dbo.tb_ParentComment");
            DropIndex("dbo.tb_ChildComment", new[] { "ParentComment_Id" });
            DropIndex("dbo.tb_ParentComment", new[] { "ProductId" });
            DropTable("dbo.tb_ChildComment");
            DropTable("dbo.tb_ParentComment");
        }
    }
}
