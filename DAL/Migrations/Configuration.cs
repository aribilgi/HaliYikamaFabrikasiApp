namespace DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // property lerde değişiklik yaparsam data kaybını kabul ediyorum ayarı!
            ContextKey = "DAL.DatabaseContext";
        }

        protected override void Seed(DAL.DatabaseContext context)
        {
            //  Migrationsu aktif ettikten sonra veritabanı oluşturduktan sonra kullanıcı oluşturma için kullandığımız seed metodundaki kodları artık buraya taşımalıyız çünkü artık bu seed metodu kullanılacak!
            if (!context.Kullanicilar.Any()) //eğer veritabanında hiç kullanıcı yoksa
            {
                Kullanici kullanici = new Kullanici() //yeni bir kullanıcı oluştur
                {
                    Adi = "Admin",
                    Durum = true,
                    Email = "admin@hafapp.co",
                    KullaniciAdi = "admin",
                    Sifre = "Admin123"
                };
                context.Kullanicilar.Add(kullanici); //yukardaki kullanıcıyı ekle
                context.SaveChanges(); //kaydı veritabanına işle
            }
        }
    }
}
