using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Musteriler")]
    public class Musteri : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Adı"), StringLength(50)]
        public string Adi { get; set; }
        [DisplayName("Soyadı"), StringLength(50)]
        public string Soyadi { get; set; }
        [StringLength(50), EmailAddress]
        public string Email { get; set; }
        [StringLength(15)]
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public virtual List<Urun> Uruns { get; set; }
        public Musteri()
        {
            Uruns = new List<Urun>();
        }
    }
}
