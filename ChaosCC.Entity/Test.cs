using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.Entity
{
    [Table("Testler", Schema = "Chaos")]
    public class Test:BaseEntity
    {
        public string Adi { get; set; }
        public string Tarih { get; set; }
    }
}
