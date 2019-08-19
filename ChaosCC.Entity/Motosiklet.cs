namespace ChaosCC.Entity
{
    public class Motosiklet : BaseEntity
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public int KullaniciId { get; set; }
        public int BaslangicSayacKM { get; set; }       
        public bool Kullanimda { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
