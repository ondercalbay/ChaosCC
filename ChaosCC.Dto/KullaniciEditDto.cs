using System;
using System.ComponentModel.DataAnnotations;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class KullaniciEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string Adi { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Soyad")]
        public string Soyadi { get; set; }

        [Display(Name = "D.Tarihi")]
        [DataType(DataType.Date)]        
        public DateTime? DogumTarihi { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        public EnuRol Rol { get; set; }

        [Display(Name = "Kan Grubu")]
        public EnuKanGrup Kangrubu { get; set; }

        [Display(Name = "Rütbesi")]
        public EnuRutbe Rutbesi { get; set; }

        [Display(Name = "Voyeger Rozet")]
        public EnuVoyegerRozet VoyagerRozet { get; set; }

        [Display(Name = "Ehliyet Ön")]
        [MaxLength(100)]
        public string EhliyetOn { get; set; }

        [Display(Name = "Ehliyet Arka")]
        [MaxLength(100)]
        public string EhliyetArka { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Yakın")]
        public string Yakin { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Yakın Cep")]
        public string YakinCep { get; set; }
                
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string SifreTekrar { get; set; }

        [Required]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        public string EPosta { get; set; }

                
        public int EkleyenId { get; set; }
        public int GuncelleyenId { get; set; }

    }
}
