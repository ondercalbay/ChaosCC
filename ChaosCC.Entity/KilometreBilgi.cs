using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("KilometreBilgileri", Schema = "Kulup")]
    public class KilometreBilgi : BaseEntity
    {
        public int KullaniciId { get; set; }
        public int MotosikletId { get; set; }
        public int Sayac { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Motosiklet Motosiklet { get; set; }
    }

}
