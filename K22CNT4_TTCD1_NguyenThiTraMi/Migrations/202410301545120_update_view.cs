namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_view : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tbl_Review", "ProductId");
            AddForeignKey("dbo.Tbl_Review", "ProductId", "dbo.Tbl_Product", "NttmId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Review", "ProductId", "dbo.Tbl_Product");
            DropIndex("dbo.Tbl_Review", new[] { "ProductId" });
        }
    }
}
