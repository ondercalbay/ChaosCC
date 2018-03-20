using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Entity
{
    public class Aidat:BaseEntity
    {
        public int KullaniciId { get; set; }
        public EnuAidatDurum Durum { get; set; }
    }
}
