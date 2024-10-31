namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateThongKe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ThongKes", newName: "Tbl_ThongKe");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tbl_ThongKe", newName: "ThongKes");
        }
    }
}
