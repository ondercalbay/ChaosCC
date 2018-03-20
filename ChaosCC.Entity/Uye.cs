using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Entity
{
    [Table("Uyeler", Schema = "Chaos")]
    public class Uye : BaseEntity
    {
        public int KullaniciId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lakap { get; set; }
        public EnuKanGruplari Kangrubu { get; set; }
        public EnuRutbeler Rutbesi { get; set; }
        public EnuVoyegerRozetleri VoyagerRozet { get; set; }
        public int Km { get; set; }
    }

   
}
