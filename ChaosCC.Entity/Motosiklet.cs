using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    public class Motosiklet : BaseEntity
    {
        public string Adi { get; set; }
        public int KullaniciId { get; set; }
        public int BaslangicSayacKM { get; set; }
        public int SonSayacKM { get; set; }        
        public bool Kullanimda { get; set; }
    }
}
