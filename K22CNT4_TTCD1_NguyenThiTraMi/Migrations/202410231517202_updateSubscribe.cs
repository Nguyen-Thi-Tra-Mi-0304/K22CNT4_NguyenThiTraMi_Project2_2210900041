namespace K22CNT4_TTCD1_NguyenThiTraMi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSubscribe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_Subscribe", "NttmEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_Subscribe", "NttmEmail", c => c.String());
        }
    }
}
