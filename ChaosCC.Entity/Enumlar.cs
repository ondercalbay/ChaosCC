using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    public partial class Enumlar
    {
        public enum EnuAidatDurum
        {
            Odenmedi = 0,
            Odendi = 1,
            Donduruldu = 2
        }
        public enum EnuKanGruplari
        {
            ArhPositive = 1,
            BrhPositive = 2,
            ABrhPositive = 3,
            OrhPositive = 4,
            ArhNegative = 5,
            BrhNegative = 6,
            ABrhNegative = 7,
            OrhNegative = 8
        }
        public enum EnuVoyegerRozetleri
        {
            Voyoger1 = 1,
            Voyoger2 = 2,
            Voyoger3 = 3,
            VoyogerCaptain = 4
        }

        public enum EnuEtkinlikTuru
        {
            [Display(Name = "Cuma Toplantısı")]
            CumaToplantisi = 1,
            [Display(Name = "Önemli Gün")]
            OnemliGun = 2            
        }
    }
}
