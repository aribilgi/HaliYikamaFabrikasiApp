using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Musteriler")]
    public class Musteri : IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public virtual List<Urun> Uruns { get; set; }
        public Musteri()
        {
            Uruns = new List<Urun>();
        }
    }
}
