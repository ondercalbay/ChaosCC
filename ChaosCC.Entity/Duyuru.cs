﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Entity
{
    [Table("Duyurular", Schema = "Chaos")]
    public class Duyuru : BaseEntity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
        [Required]
        public EnuDuyuruTipi DuyuruTipi { get; set; }
        [Required]
        [MaxLength(100)]
        public string Baslik { get; set; }
        [Required]
        public string Yazi { get; set; }
    }


}
