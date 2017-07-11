using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class DuyuruEditDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        [Required]
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        [Required]
        [MaxLength(100)]
        public string Baslik { get; set; }
        [Required]
        public string Yazi { get; set; }
        public int EkleyenId { get; set; }
        public int GuncelleyenId { get; set; }
    }
}
