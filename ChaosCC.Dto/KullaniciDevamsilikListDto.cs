using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class KullaniciDevamsilikListDto
    {
        public KullaniciListDto Kullanici { get; set; }

        public List<KullaniciDevamsizlikDto> Devamsizlik { get; set; }
    }
}
