using System;
using System.ComponentModel.DataAnnotations;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class KullaniciDevamsizlikDto
    {
        public int EtkinlikId { get; set; }

        [Display(Name = "Etkinlik Türü")]
        public EnuEtkinlikTuru EtkinlikTuru { get; set; }

        [Display(Name = "Yer")]
        public string EtkinlikAdi { get; set; }

        [Display(Name = "Tarih")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EtkinlikTarihi { get; set; }

        [Display(Name = "Etkinlik Açıklaması")]
        public string EtkinlikAciklama { get; set; }

        [Display(Name = "Mazeret")]
        public string DevamsizlikAciklama { get; set; }

        [Display(Name = "Durum")]
        public bool Geldi { get; set; }
    }
}
