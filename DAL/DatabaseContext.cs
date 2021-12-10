using Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {        
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            //DatabaseContext i nasýl oluþturduk? 
            /*
             * Dal projesine sað týk add new item dedik
             * açýlan pencerede Data sekmesine týklayýp ilk sýradaki entity data model i seçtik ve Next dedik
             * alttaki Ýsim kýsmýna DatabaseContext i verip next dedik
             * açýlan pencereden 3. seçenek olan empty code first modeli seçip ok dedik
             */
        }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}