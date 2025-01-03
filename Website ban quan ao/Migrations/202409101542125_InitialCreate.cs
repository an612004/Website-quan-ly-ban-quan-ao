﻿namespace Website_ban_quan_ao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chitietdonhangs",
                c => new
                    {
                        Madon = c.Int(nullable: false),
                        Masp = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Soluong = c.Int(),
                        Dongia = c.Decimal(precision: 18, scale: 2),
                        GiaGocSp = c.Decimal(precision: 18, scale: 2),
                        size = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donhangs", t => t.Masp, cascadeDelete: true)
                .Index(t => t.Masp);
            
            CreateTable(
                "dbo.Donhangs",
                c => new
                    {
                        Madon = c.Int(nullable: false, identity: true),
                        Ngaydat = c.DateTime(nullable: false),
                        Tinhtrang = c.Int(),
                        Manguoidung = c.Int(),
                        TenSanPham = c.String(),
                        GiaTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuong = c.Int(nullable: false),
                        Size = c.String(),
                        TenNguoiDat = c.String(),
                        Email = c.String(),
                        DiaChi = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.Madon)
                .ForeignKey("dbo.Nguoidungs", t => t.Manguoidung)
                .Index(t => t.Manguoidung);
            
            CreateTable(
                "dbo.Nguoidungs",
                c => new
                    {
                        Manguoidung = c.Int(nullable: false, identity: true),
                        Hoten = c.String(),
                        Email = c.String(),
                        Dienthoai = c.String(),
                        Matkhau = c.String(),
                        IDQuyen = c.Int(),
                        Diachi = c.String(),
                    })
                .PrimaryKey(t => t.Manguoidung)
                .ForeignKey("dbo.Phanquyens", t => t.IDQuyen)
                .Index(t => t.IDQuyen);
            
            CreateTable(
                "dbo.Phanquyens",
                c => new
                    {
                        IDQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(),
                    })
                .PrimaryKey(t => t.IDQuyen);
            
            CreateTable(
                "dbo.Hangsanxuats",
                c => new
                    {
                        Mahang = c.Int(nullable: false, identity: true),
                        Tenhang = c.String(),
                    })
                .PrimaryKey(t => t.Mahang);
            
            CreateTable(
                "dbo.Sanphams",
                c => new
                    {
                        Masp = c.Int(nullable: false, identity: true),
                        Tensp = c.String(),
                        Giatien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaGoc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sale = c.Boolean(nullable: false),
                        Soluong = c.Int(),
                        Mota = c.String(),
                        Mausac = c.String(),
                        Kichco = c.Int(),
                        Sanphammoi = c.Boolean(),
                        Anhbia = c.String(),
                        Mahang = c.Int(),
                        Makieudang = c.Int(),
                    })
                .PrimaryKey(t => t.Masp)
                .ForeignKey("dbo.Hangsanxuats", t => t.Mahang)
                .ForeignKey("dbo.Kieudangs", t => t.Makieudang)
                .Index(t => t.Mahang)
                .Index(t => t.Makieudang);
            
            CreateTable(
                "dbo.Kieudangs",
                c => new
                    {
                        Makieudang = c.Int(nullable: false, identity: true),
                        Tenkieudang = c.String(),
                    })
                .PrimaryKey(t => t.Makieudang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanphams", "Makieudang", "dbo.Kieudangs");
            DropForeignKey("dbo.Sanphams", "Mahang", "dbo.Hangsanxuats");
            DropForeignKey("dbo.Chitietdonhangs", "Masp", "dbo.Donhangs");
            DropForeignKey("dbo.Donhangs", "Manguoidung", "dbo.Nguoidungs");
            DropForeignKey("dbo.Nguoidungs", "IDQuyen", "dbo.Phanquyens");
            DropIndex("dbo.Sanphams", new[] { "Makieudang" });
            DropIndex("dbo.Sanphams", new[] { "Mahang" });
            DropIndex("dbo.Nguoidungs", new[] { "IDQuyen" });
            DropIndex("dbo.Donhangs", new[] { "Manguoidung" });
            DropIndex("dbo.Chitietdonhangs", new[] { "Masp" });
            DropTable("dbo.Kieudangs");
            DropTable("dbo.Sanphams");
            DropTable("dbo.Hangsanxuats");
            DropTable("dbo.Phanquyens");
            DropTable("dbo.Nguoidungs");
            DropTable("dbo.Donhangs");
            DropTable("dbo.Chitietdonhangs");
        }
    }
}
