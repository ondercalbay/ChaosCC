﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.Dto
{
    public class EtkinlikListDto
    {
        public int Id { get; set; }

        public string Yer { get; set; }

        [Display(Name = "Etkinlik Türü")]
        public EnuEtkinlikTuru EtlinlikTuru { get; set; }

        public DateTime Tarih { get; set; }        
    }
}
