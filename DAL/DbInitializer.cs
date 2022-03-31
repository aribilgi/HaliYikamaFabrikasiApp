using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Entities;

namespace DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
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
            //base.Seed(context);
        }
    }
}
