using ChaosCC.Entity;
using System.Data.Entity;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class ChaosContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<KilometreBilgi> KilometreBilgileri { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
    }
}
