namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        Adi = c.String(maxLength: 50),
                        Soyadi = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 50),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musteriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(),
                        Cinsi = c.String(),
                        Olcu = c.String(),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlisTarihi = c.DateTime(nullable: false),
                        TeslimTarihi = c.DateTime(nullable: false),
                        MusteriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musteriler", t => t.MusteriId, cascadeDelete: true)
                .Index(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunler", "MusteriId", "dbo.Musteriler");
            DropIndex("dbo.Urunler", new[] { "MusteriId" });
            DropTable("dbo.Urunler");
            DropTable("dbo.Musteriler");
            DropTable("dbo.Kullanicilar");
        }
    }
}
