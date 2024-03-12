namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Web : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_News", newName: "News");
            AddColumn("dbo.News", "CreatedBy", c => c.String());
            AddColumn("dbo.News", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "Modifiedby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Modifiedby");
            DropColumn("dbo.News", "ModifiedDate");
            DropColumn("dbo.News", "CreatedDate");
            DropColumn("dbo.News", "CreatedBy");
            RenameTable(name: "dbo.News", newName: "tb_News");
        }
    }
}
