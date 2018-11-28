using ChaosCC.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ChaosCC.Dto
{
    public class DuyuruListDto
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        [Display(Name = "Duyuru Tipi")]
        public EnuDuyuruTipi DuyuruTipi { get; set; }

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
