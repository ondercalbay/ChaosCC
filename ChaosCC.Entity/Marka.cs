using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaosCC.Entity
{
    [Table("Markalar", Schema = "Kulup")]
    public class Marka: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }


    }
}
