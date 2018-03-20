using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("Toplantilar", Schema = "Chaos")]
    public class Toplanti : BaseEntity
    {
        [Required]
        public DateTime Tarih { get; set; }
        public string Yer { get; set; }
        public EnuToplantiTipi ToplantiTipi { get; set; }
        [MaxLength(2000)]
        public string Aciklama { get; set; }
    }

    public enum EnuToplantiTipi
    {
        CumaToplantisi = 1,
        Etkinlik = 2,
        Gezi = 3,
        Egitim = 4,
        Diger = 5
    }
}
