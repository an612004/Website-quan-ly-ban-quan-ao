namespace Website_ban_quan_ao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinTucs", "Anhbia", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.TinTucs", "HinhAnh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinTucs", "HinhAnh", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.TinTucs", "Anhbia");
        }
    }
}
