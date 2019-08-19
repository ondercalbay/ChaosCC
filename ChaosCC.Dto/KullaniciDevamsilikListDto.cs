using System.Collections.Generic;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class KullaniciDevamsilikListDto
    {
        public EnuTarihAralik TarihAralik { get; set; }
        public KullaniciListDto Kullanici { get; set; }

        public List<KullaniciDevamsizlikDto> Devamsizlik { get; set; }
    }
}
