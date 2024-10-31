namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Posts", "NttmAlias", c => c.String(maxLength: 150));
            AlterColumn("dbo.Tbl_Posts", "NttmImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_Posts", "NttmSeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_Posts", "NttmSeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tbl_Posts", "NttmSeoKeyWords", c => c.String(maxLength: 200));
            AlterColumn("dbo.Tbl_Product", "NttmAlias", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_Product", "NttmProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tbl_Product", "NttmImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_Product", "NttmSeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_Product", "NttmSeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tbl_Product", "NttmSeoKeyWords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Product", "NttmSeoKeyWords", c => c.String());
            AlterColumn("dbo.Tbl_Product", "NttmSeoDescription", c => c.String());
            AlterColumn("dbo.Tbl_Product", "NttmSeoTitle", c => c.String());
            AlterColumn("dbo.Tbl_Product", "NttmImage", c => c.String());
            AlterColumn("dbo.Tbl_Product", "NttmProductCode", c => c.String());
            AlterColumn("dbo.Tbl_Product", "NttmAlias", c => c.String());
            AlterColumn("dbo.Tbl_Posts", "NttmSeoKeyWords", c => c.String());
            AlterColumn("dbo.Tbl_Posts", "NttmSeoDescription", c => c.String());
            AlterColumn("dbo.Tbl_Posts", "NttmSeoTitle", c => c.String());
            AlterColumn("dbo.Tbl_Posts", "NttmImage", c => c.String());
            AlterColumn("dbo.Tbl_Posts", "NttmAlias", c => c.String());
        }
    }
}
