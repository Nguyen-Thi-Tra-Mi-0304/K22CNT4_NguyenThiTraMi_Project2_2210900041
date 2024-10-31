namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_Posts", "NttmPost_NttmId", "dbo.Tbl_Posts");
            DropIndex("dbo.Tbl_Posts", new[] { "NttmPost_NttmId" });
            AlterColumn("dbo.Tbl_Category", "NttmTitle", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Tbl_Category", "NttmSeoTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.Tbl_Category", "NttmSeoDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.Tbl_Category", "NttmSeoKeyWords", c => c.String(maxLength: 150));
            DropColumn("dbo.Tbl_Posts", "NttmPost_NttmId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Posts", "NttmPost_NttmId", c => c.Int());
            AlterColumn("dbo.Tbl_Category", "NttmSeoKeyWords", c => c.String());
            AlterColumn("dbo.Tbl_Category", "NttmSeoDescription", c => c.String());
            AlterColumn("dbo.Tbl_Category", "NttmSeoTitle", c => c.String());
            AlterColumn("dbo.Tbl_Category", "NttmTitle", c => c.String());
            CreateIndex("dbo.Tbl_Posts", "NttmPost_NttmId");
            AddForeignKey("dbo.Tbl_Posts", "NttmPost_NttmId", "dbo.Tbl_Posts", "NttmId");
        }
    }
}
