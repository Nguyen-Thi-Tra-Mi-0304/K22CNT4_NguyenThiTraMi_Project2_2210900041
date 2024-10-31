﻿namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateindentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
    }
}