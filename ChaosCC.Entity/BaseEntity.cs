﻿using System;

namespace ChaosCC.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int EkleyenId { get; set; }
        public DateTime EklemeZamani { get; set; }
        public int GuncelleyenId { get; set; }
        public DateTime GuncellemeZamani { get; set; }
        public bool Aktif { get; set; }
    }
}
