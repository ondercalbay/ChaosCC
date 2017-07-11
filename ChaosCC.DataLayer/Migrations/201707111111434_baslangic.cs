namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baslangic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chaos.Duyurular",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        DuyuruTipi = c.Int(nullable: false),
                        Baslik = c.String(nullable: false, maxLength: 100),
                        Yazi = c.String(nullable: false),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Chaos.KilometreBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        SonSayac = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Aciklama = c.String(),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Sistem.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 50),
                        Soyadi = c.String(nullable: false, maxLength: 50),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 20),
                        EMail = c.String(nullable: false, maxLength: 100),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Chaos.Uyeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        Lakap = c.String(nullable: false, maxLength: 50),
                        Kangrubu = c.Int(nullable: false),
                        Rutbesi = c.Int(nullable: false),
                        VoyagerRozet = c.Int(nullable: false),
                        Km = c.Int(nullable: false),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Chaos.Uyeler");
            DropTable("Sistem.Kullanicilar");
            DropTable("Chaos.KilometreBilgileri");
            DropTable("Chaos.Duyurular");
        }
    }
}
