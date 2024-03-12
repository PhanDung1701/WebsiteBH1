﻿namespace WebsiteBH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.News", newName: "tb_News");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_News", newName: "News");
        }
    }
}
