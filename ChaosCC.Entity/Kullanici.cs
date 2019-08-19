using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Entity
{
    [Table("Kullanicilar", Schema = "Sistem")]
    public class Kullanici
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }

        [Display(Name = "D.Tarihi")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DogumTarihi { get; set; }

        [Required]
        [MaxLength(100)]
        public string EPosta { get; set; }

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
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

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

        [Required]
        [MaxLength(20)]
        public string Sifre { get; set; }  
        
        public int EkleyenId { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int GuncelleyenId { get; set; }
        public DateTime GuncellemeZamani { get; set; }
        public bool Aktif { get; set; }
    }
}