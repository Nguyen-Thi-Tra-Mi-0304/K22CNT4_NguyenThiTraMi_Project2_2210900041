namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTBThongKe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThongKes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThoiGian = c.DateTime(nullable: false),
                        SoTruyCap = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tbl_News", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "ViewCount");
            DropColumn("dbo.Tbl_Posts", "ViewCount");
            DropColumn("dbo.Tbl_News", "ViewCount");
            DropTable("dbo.ThongKes");
        }
    }
}
