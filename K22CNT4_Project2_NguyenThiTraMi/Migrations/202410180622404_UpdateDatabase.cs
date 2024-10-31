namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_News", "NttmCategoryId", "dbo.Tbl_Category");
            DropIndex("dbo.Tbl_News", new[] { "NttmCategoryId" });
            AddColumn("dbo.Tbl_News", "NttmCategory_NttmId", c => c.Int());
            CreateIndex("dbo.Tbl_News", "NttmCategory_NttmId");
            AddForeignKey("dbo.Tbl_News", "NttmCategory_NttmId", "dbo.Tbl_Category", "NttmId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_News", "NttmCategory_NttmId", "dbo.Tbl_Category");
            DropIndex("dbo.Tbl_News", new[] { "NttmCategory_NttmId" });
            DropColumn("dbo.Tbl_News", "NttmCategory_NttmId");
            CreateIndex("dbo.Tbl_News", "NttmCategoryId");
            AddForeignKey("dbo.Tbl_News", "NttmCategoryId", "dbo.Tbl_Category", "NttmId", cascadeDelete: true);
        }
    }
}
