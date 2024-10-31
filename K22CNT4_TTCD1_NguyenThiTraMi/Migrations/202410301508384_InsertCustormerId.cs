namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustormerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Order", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Order", "CustomerId");
        }
    }
}
