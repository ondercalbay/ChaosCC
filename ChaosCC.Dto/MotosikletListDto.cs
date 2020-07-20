using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Dto
{
    public class MotosikletListDto
    {
        public int Id { get; set; }
        [Display(Name = "Marka")]
        public string MarkaAdi { get; set; }
        [Display(Name = "Model")]
        public string ModelAdi { get; set; }
        public string Plaka { get; set; }
        [Display(Name = "Sahibi")]
        public string KullaniciKullaniciAdi { get; set; }
        [Display(Name = "Yil")]
        public int Yil { get; set; }
        [Display(Name = "Kullanımda")]
        public bool Kullanimda { get; set; }

    }
}
