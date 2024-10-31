namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProductCategory", "Alias", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Tbl_ProductCategory", "NttmIcon", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoKeyWords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoKeyWords", c => c.String());
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoDescription", c => c.String());
            AlterColumn("dbo.Tbl_ProductCategory", "NttmSeoTitle", c => c.String());
            AlterColumn("dbo.Tbl_ProductCategory", "NttmIcon", c => c.String());
            DropColumn("dbo.Tbl_ProductCategory", "Alias");
        }
    }
}
