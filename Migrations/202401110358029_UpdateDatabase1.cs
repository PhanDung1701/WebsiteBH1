namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
