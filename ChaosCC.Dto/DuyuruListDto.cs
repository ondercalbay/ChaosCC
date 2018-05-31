using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
