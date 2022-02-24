using Entities;
using System.Data.Entity;

namespace DAL
{
    public class DatabaseContext : DbContext
    {        
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            //DatabaseContext i nas�l olu�turduk? 
            /*
             * Dal projesine sa� t�k add new item dedik
             * a��lan pencerede Data sekmesine t�klay�p ilk s�radaki entity data model i se�tik ve Next dedik
             * alttaki �sim k�sm�na DatabaseContext i verip next dedik
             * a��lan pencereden 3. se�enek olan empty code first modeli se�ip ok dedik
             */
            Database.SetInitializer(new DbInitializer()); //veritaban�na ba�lang�� kay�tlar�n�n eklenmesi i�in olu�turdu�umuz DbInitializer � buraya ekliyoruz
        }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}