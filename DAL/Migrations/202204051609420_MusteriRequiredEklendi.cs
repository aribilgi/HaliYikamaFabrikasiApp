namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusteriRequiredEklendi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musteriler", "Adi", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Musteriler", "Soyadi", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Musteriler", "Telefon", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Musteriler", "Adres", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musteriler", "Adres", c => c.String());
            AlterColumn("dbo.Musteriler", "Telefon", c => c.String(maxLength: 15));
            AlterColumn("dbo.Musteriler", "Soyadi", c => c.String(maxLength: 50));
            AlterColumn("dbo.Musteriler", "Adi", c => c.String(maxLength: 50));
        }
    }
}
