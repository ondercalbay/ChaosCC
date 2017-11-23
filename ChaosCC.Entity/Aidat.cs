using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    public class Aidat:BaseEntity
    {
        public int KullaniciId { get; set; }
        public EnuAidatDurum Durum { get; set; }
    }

    public enum EnuAidatDurum
    {
        Odenmedi = 0,
        Odendi = 1,
        Donduruldu=2
    }
}
