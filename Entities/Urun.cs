using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Urunler")]
    public class Urun : IEntity
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string Cinsi { get; set; }
        public string Olcu { get; set; }
        public decimal Tutar { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
