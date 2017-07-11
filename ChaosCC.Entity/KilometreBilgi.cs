using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    [Table("KilometreBilgileri", Schema = "Chaos")]
    public class KilometreBilgi : BaseEntity
    {
        public int KullaniciId { get; set; }
        public int SonSayac { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
    }
}
