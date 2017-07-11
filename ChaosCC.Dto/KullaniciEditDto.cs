using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Dto
{
    public class KullaniciEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }
        [Required]
        [MaxLength(50)]
        public string KullaniciAdi { get; set; }
        [Required]
        [MaxLength(20)]
        public string Sifre { get; set; }
        [Required]
        [MaxLength(100)]
        public string EMail { get; set; }
        public int EkleyenId { get; set; }
        public int GuncelleyenId { get; set; }

    }
}
