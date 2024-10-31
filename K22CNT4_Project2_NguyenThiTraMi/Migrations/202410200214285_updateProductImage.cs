namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ProductImage",
                c => new
                    {
                        NttmId = c.Int(nullable: false, identity: true),
                        NttmProductId = c.Int(nullable: false),
                        NttmImage = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        NttmProduct_NttmId = c.Int(),
                    })
                .PrimaryKey(t => t.NttmId)
                .ForeignKey("dbo.Tbl_Product", t => t.NttmProduct_NttmId)
                .Index(t => t.NttmProduct_NttmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_ProductImage", "NttmProduct_NttmId", "dbo.Tbl_Product");
            DropIndex("dbo.Tbl_ProductImage", new[] { "NttmProduct_NttmId" });
            DropTable("dbo.Tbl_ProductImage");
        }
    }
}
