namespace Website_ban_quan_ao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chitietdonhangs", "Masp", "dbo.Donhangs");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.Chitietdonhangs", "Masp", "dbo.Donhangs", "Madon", cascadeDelete: true);
        }
    }
}
