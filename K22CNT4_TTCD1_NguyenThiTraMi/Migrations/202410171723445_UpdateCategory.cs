namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Category", "NttmAlias", c => c.String());
            AddColumn("dbo.Tbl_Posts", "NttmAlias", c => c.String());
            AddColumn("dbo.Tbl_Product", "NttmAlias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "NttmAlias");
            DropColumn("dbo.Tbl_Posts", "NttmAlias");
            DropColumn("dbo.Tbl_Category", "NttmAlias");
        }
    }
}
