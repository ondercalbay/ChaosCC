using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    [Table("Modeller", Schema = "Kulup")]
    public class Model: BaseEntity
    {
        [Required]        
        public int? MarkaId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; }
    }
}
