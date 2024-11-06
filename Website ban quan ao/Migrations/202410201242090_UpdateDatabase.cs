namespace Website_ban_quan_ao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Chitietdonhangs", "Masp", "dbo.Sanphams", "Masp", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chitietdonhangs", "Masp", "dbo.Sanphams");
        }
    }
}
