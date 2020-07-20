﻿using System.ComponentModel.DataAnnotations;

namespace ChaosCC.Dto
{
    public class MarkaEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }
    }
}
