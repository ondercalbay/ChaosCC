using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("Motosikletler", Schema = "Kulup")]
    public class Motosiklet : BaseEntity
    {
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public int Yil { get; set; }
        [Required]        
        public int KullaniciId { get; set; }
        public int BaslangicSayacKM { get; set; }
        public int SayacKM { get; set; }
        [MaxLength(15)]
        public string Plaka { get; set; }
        public bool Kullanimda { get; set; }
        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; }
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
    }
}
