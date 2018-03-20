using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("Devamsizliklar", Schema = "Chaos")]
    public class Devamsizlik : BaseEntity
    {
        [Required]        
        public int EtkinlikId { get; set; }

        [Required]
        public int KullaniciId { get; set; }

        public bool Geldi { get; set; }

        public string Aciklama { get; set; }
        
        public virtual Etkinlik Etkinlik { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
