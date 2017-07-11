using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChaosCC.Dto
{
    public class DuyuruEditDto
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Required]
        public DateTime Tarih { get; set; }
        [Required]
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        [Required]
        [MaxLength(100)]
        public string Baslik { get; set; }
        [AllowHtml]
        [Required]
        public string Yazi { get; set; }
        public int EkleyenId { get; set; }
        public int GuncelleyenId { get; set; }
    }
}
