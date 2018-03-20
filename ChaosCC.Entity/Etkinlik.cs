using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Entity
{
    [Table("Etkinlikler", Schema = "Chaos")]
    public class Etkinlik : BaseEntity
    {
        [Required]
        [MaxLength(1000)]
        public string Yer { get; set; }

        [Required]
        public EnuEtkinlikTuru EtlinlikTuru { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }
    }
}
