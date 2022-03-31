using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Kullanicilar")]
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Kullanıcı Adı"), Required, StringLength(50)]
        public string KullaniciAdi { get; set; }
        [DisplayName("Adı"), StringLength(50)]
        public string Adi { get; set; }
        [DisplayName("Soyadı"), StringLength(50)]
        public string Soyadi { get; set; }
        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; }
        [DisplayName("Şifre"), Required, StringLength(50), DataType(DataType.Password)]
        public string Sifre { get; set; }
        public bool Durum { get; set; }
        public DateTime? EklenmeTarihi { get; set; } // DateTime ın yanındaki ? bu alanın boş geçilebilir olmasını sağlar, koymazsak zorunlu olur varsayılan değeri zorunludur datetime veri türünün
        // Eğer buradaki gibi model class larımızda yeni alan ekleme veya bir property nin üzerinde değişiklik yapma gibi bir işlem yaparsak entity framework patlıyor, hata veriyor.
        // Bu hatayı çözmek için üst menüden Tools > Nuget package manager > Package Manager Console yolunu izleyerek eğer kapalıysa PMC ekranını aşağıda açıyoruz!
    }
}
