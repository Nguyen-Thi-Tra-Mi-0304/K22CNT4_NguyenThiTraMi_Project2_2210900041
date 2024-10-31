namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Order", "TypePayment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Order", "TypePayment");
        }
    }
}
