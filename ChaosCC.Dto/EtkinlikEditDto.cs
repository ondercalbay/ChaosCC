using System;
using System.ComponentModel.DataAnnotations;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class EtkinlikEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Yer { get; set; }

        [Required]
        public EnuEtkinlikTuru EtlinlikTuru { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }
    }
}
