using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Urunler")]
    public class Urun : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı"), StringLength(50), Required]
        public string UrunAdi { get; set; }
        [StringLength(50)]
        public string Cinsi { get; set; }
        [DisplayName("Ölçü"), StringLength(50), Required]
        public string Olcu { get; set; }
        public decimal Tutar { get; set; }
        [DisplayName("Alış Tarihi")]
        public DateTime AlisTarihi { get; set; }
        [DisplayName("Teslim Tarihi")]
        public DateTime TeslimTarihi { get; set; }
        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
