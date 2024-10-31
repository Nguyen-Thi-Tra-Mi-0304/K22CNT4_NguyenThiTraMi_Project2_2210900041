namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOriginalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Product", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "OriginalPrice");
        }
    }
}
