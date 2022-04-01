namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusteriUrunDegisti : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musteriler", "Adi", c => c.String(maxLength: 50));
            AlterColumn("dbo.Musteriler", "Soyadi", c => c.String(maxLength: 50));
            AlterColumn("dbo.Musteriler", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Musteriler", "Telefon", c => c.String(maxLength: 15));
            AlterColumn("dbo.Urunler", "UrunAdi", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Urunler", "Cinsi", c => c.String(maxLength: 50));
            AlterColumn("dbo.Urunler", "Olcu", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Urunler", "Olcu", c => c.String());
            AlterColumn("dbo.Urunler", "Cinsi", c => c.String());
            AlterColumn("dbo.Urunler", "UrunAdi", c => c.String());
            AlterColumn("dbo.Musteriler", "Telefon", c => c.String());
            AlterColumn("dbo.Musteriler", "Email", c => c.String());
            AlterColumn("dbo.Musteriler", "Soyadi", c => c.String());
            AlterColumn("dbo.Musteriler", "Adi", c => c.String());
        }
    }
}
