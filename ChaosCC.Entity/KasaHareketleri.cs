using System;

namespace ChaosCC.Entity
{
    public class KasaHareketleri : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public int KasaId { get; set; }
        public string Aciklama { get; set; }
        public decimal Tutar { get; set; }

    }
}
