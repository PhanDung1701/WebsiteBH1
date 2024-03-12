namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Databate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "CreateDate");
        }
    }
}
