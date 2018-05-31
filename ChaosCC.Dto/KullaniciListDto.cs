using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Dto
{
    public class KullaniciListDto
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Adi { get; set; }
        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
    }
}
