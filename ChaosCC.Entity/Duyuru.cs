using System;
using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Entity
{
    public class Duyuru : BaseEntity
    {
        [Required]        
        public DateTime Tarih { get; set; }
        [Required]        
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        [Required]
        [MaxLength(100)]
        public string Baslik { get; set; }
        [Required]        
        public string Yazi { get; set; }
    }
    public enum EnuDuyuruTipi
    {
        Karar = 1,
        Duyuru = 2,
        Bilgilendirme = 3
    }

}
