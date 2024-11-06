namespace Website_ban_quan_ao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 200),
                        NoiDung = c.String(nullable: false),
                        HinhAnh = c.String(nullable: false, maxLength: 300),
                        NgayTao = c.DateTime(nullable: false),
                        NgayCapNhat = c.DateTime(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTucs");
        }
    }
}
