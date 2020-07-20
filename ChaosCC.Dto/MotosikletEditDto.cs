using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Dto
{
    public class MotosikletEditDto
    {
        public int Id { get; set; }
        [Display(Name = "Marka")]
        public int MarkaId { get; set; }
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        [Display(Name = "Yil")]
        public int Yil { get; set; }
        [Required]
        [Display(Name = "Sahibi")]
        public int KullaniciId { get; set; }
        [Display(Name = "Başlangıç Sayaç(KM)")]
        public int BaslangicSayacKM { get; set; }
        [Display(Name = "Sayaç(KM)")]
        public int SayacKM { get; set; }
        [MaxLength(15)]
        public string Plaka { get; set; }
        [Display(Name = "Kullanımda")]
        public bool Kullanimda { get; set; }  
        
       
    }
}
