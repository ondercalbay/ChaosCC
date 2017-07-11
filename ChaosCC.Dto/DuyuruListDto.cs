using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class DuyuruListDto
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        public string Baslik { get; set; }
    }
}
