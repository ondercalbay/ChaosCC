using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class DevamsizlikListDto
    {
        public int Id { get; set; }
        
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public bool Geldi { get; set; }
        public string Aciklama { get; set; }
    }

    public class DevamsizlikGridDto
    {
        public int Id { get; set; }
        public string EtkinlikAdi { get; set; }
        public List<DevamsizlikListDto> Grid { get; set; }
    }
}
