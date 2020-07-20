using ChaosCC.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class ChaosContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }        
        //public DbSet<KilometreBilgi> KilometreBilgileri { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Devamsizlik> Devamsizliklar { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }

        public DbSet<Motosiklet> Motosikletler { get; set; }

        public DbSet<Marka> Markalar { get; set; }

        public DbSet<Model> Modeller { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();             

            base.OnModelCreating(modelBuilder);
        } 
    }
}
