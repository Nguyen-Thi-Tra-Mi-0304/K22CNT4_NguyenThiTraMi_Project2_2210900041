namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Posts", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_Product", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "IsActive");
            DropColumn("dbo.Tbl_Posts", "IsActive");
            DropColumn("dbo.Tbl_News", "IsActive");
            DropColumn("dbo.Tbl_Category", "IsActive");
        }
    }
}
