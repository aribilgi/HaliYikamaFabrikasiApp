using Entities;
using System.Data.Entity;

namespace Data.DAL
{
    public class DatabaseContext : DbContext
    {        
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            
            //Database.SetInitializer(new DbInitializer()); //veritabanýna baþlangýç kayýtlarýnýn eklenmesi için oluþturduðumuz DbInitializer ý buraya ekliyoruz
        }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}