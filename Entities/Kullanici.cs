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
        [ScaffoldColumn(false)] // bu kod EklenmeTarihi alanının ön yüz sayfalarında otomatik textbox oluşturmasını engeller
        public DateTime? EklenmeTarihi { get; set; } // DateTime ın yanındaki ? bu alanın boş geçilebilir olmasını sağlar, koymazsak zorunlu olur varsayılan değeri zorunludur datetime veri türünün
        // Eğer buradaki gibi model class larımızda yeni alan ekleme veya bir property nin üzerinde değişiklik yapma gibi bir işlem yaparsak entity framework patlıyor, hata veriyor.
        // Bu hatayı çözmek için üst menüden Tools > Nuget package manager > Package Manager Console yolunu izleyerek eğer kapalıysa PMC ekranını aşağıda açıyoruz!
        // Migration işlemini DAL projesini seçerek yapmalıyız
        // Bunun için PMC konsolunda üst kısımda solution içindeki projelerin listelendiği menüden Default project DAL projesini seçmeliyiz yoksa o anda hangi projedeysek migration u oraya kurar önemli!
        // Migrationsu aktif etmek için PMC de default project den DAL ı seçip PMC kod yazma alanına enable-migrations yazıp enter a basıyoruz. DAL projesine Migrations isminde bir klasör ve içine ilgili class lar ekleniyor.
        // Eğer işlemde hata verirse sırayla web.config deki connection string var mı varsa veritabanı bilgileri doğru mu kontrol et!
        // Web.config doğruysa Nuget dan Entity framework yüklü ve güncel mi kontrol et!
        // enable-migrations kodunda yazım yanlışı var mı kontrol et!
        // Bir sonraki işlem PMC kod kısmına update-database yazıp enter a basıyoruz
        // İşlem başarılıysa, veritabanı güncellendiyse running seed yazar ve seed metodu çalıştırılır.
        // Eğer update-database den sonra hata mesajları çıkarsa solution explorer dan Dal katmanında oluşan Migrations klasörünü sağ tık sil de ve yukardaki işlemleri yeniden yap
        
        // Enable-migrations olayı sadece ilk seferde yapılıyor!!!
        // Daha sonra model class larında yapılacak her değişiklik için add-migration migrationAdı şeklinde kod yazarak veritabanını update-database ile güncellemeliyiz!
        // Önce add-migration sonra update-database !!
    }
}
