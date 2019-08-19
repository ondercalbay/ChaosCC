using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class DuyuruEditDto
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}" ,ApplyFormatInEditMode =true)]
        public DateTime Tarih { get; set; }
        [Required]
        [Display(Name = "Duyuru Tİpi")]
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }
        [AllowHtml]
        [Required]
        [Display(Name = "Yazı")]
        public string Yazi { get; set; }
        public int EkleyenId { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int GuncelleyenId { get; set; }
    }
}
