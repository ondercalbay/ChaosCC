using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("Uyeler", Schema = "Chaos")]
    public class Uye : BaseEntity
    {
        public int KullaniciId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lakap { get; set; }
        public KanGruplari Kangrubu { get; set; }
        public Rutbeler Rutbesi { get; set; }
        public VoyegerRozetleri VoyagerRozet { get; set; }
        public int Km { get; set; }
    }

    public enum Rutbeler
    {
        HangAround = 1,
        HangAround1 = 2,
        HangAround2 = 3,
        HangAround3 = 4,
        Prospect = 5,
        Member = 6,
        KidemliMember = 7
    }
    public enum KanGruplari
    {
        ArhPositive = 1,
        BrhPositive = 2,
        ABrhPositive = 3,
        OrhPositive = 4,
        ArhNegative = 5,
        BrhNegative = 6,
        ABrhNegative = 7,
        OrhNegative = 8
    }
    public enum VoyegerRozetleri
    {
        Voyoger1 = 1,
        Voyoger2 = 2,
        Voyoger3 = 3,
        VoyogerCaptain = 4
    }
}
