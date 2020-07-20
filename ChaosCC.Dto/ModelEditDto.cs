using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Dto
{
    public class ModelEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string Adi { get; set; }

        [Required]
        public int MarkaId { get; set; }

        public string MarkaAdi { get; set; }

    }
}
