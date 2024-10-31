namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCommon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_ProductCategory", "NttmCreatedBy", c => c.String());
            AddColumn("dbo.Tbl_ProductCategory", "NttmCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tbl_ProductCategory", "NttmModifierDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tbl_ProductCategory", "NttmModifierBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_ProductCategory", "NttmModifierBy");
            DropColumn("dbo.Tbl_ProductCategory", "NttmModifierDate");
            DropColumn("dbo.Tbl_ProductCategory", "NttmCreatedDate");
            DropColumn("dbo.Tbl_ProductCategory", "NttmCreatedBy");
        }
    }
}
