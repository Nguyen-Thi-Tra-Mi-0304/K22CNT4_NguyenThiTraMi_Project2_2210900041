namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableWishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Wishlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Wishlist", "ProductId", "dbo.Tbl_Product");
            DropIndex("dbo.Tbl_Wishlist", new[] { "ProductId" });
            DropTable("dbo.Tbl_Wishlist");
        }
    }
}
