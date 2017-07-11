using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class ChaosContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<KilometreBilgi> KilometreBilgileri { get; set; }

        public DbSet<Test> Testler { get; set; }

    }
}
