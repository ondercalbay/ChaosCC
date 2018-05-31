using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class DevamsizlikListDto
    {
        public int Id { get; set; }
        
        public int KullaniciId { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        public bool Geldi { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }

    public class DevamsizlikGridDto
    {
        public int Id { get; set; }
        public EtkinlikEditDto Etkinlik { get; set; }
        public List<DevamsizlikListDto> Grid { get; set; }
    }
}
