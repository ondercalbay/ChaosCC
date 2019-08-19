namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class motor2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Motosiklets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Model = c.String(),
                        Yil = c.Int(nullable: false),
                        KullaniciId = c.Int(nullable: false),
                        BaslangicSayacKM = c.Int(nullable: false),
                        Kullanimda = c.Boolean(nullable: false),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sistem.Kullanicilar", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId);
            
            AddColumn("Sistem.Kullanicilar", "DogumTarihi", c => c.DateTime());
            AddColumn("Sistem.Kullanicilar", "Kangrubu", c => c.Int(nullable: false));
            AddColumn("Sistem.Kullanicilar", "Rutbesi", c => c.Int(nullable: false));
            AddColumn("Sistem.Kullanicilar", "VoyagerRozet", c => c.Int(nullable: false));
            AddColumn("Sistem.Kullanicilar", "EhliyetOn", c => c.String(maxLength: 100));
            AddColumn("Sistem.Kullanicilar", "EhliyetArka", c => c.String(maxLength: 100));
            DropTable("Chaos.Uyeler");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Motosiklets", "KullaniciId", "Sistem.Kullanicilar");
            DropIndex("dbo.Motosiklets", new[] { "KullaniciId" });
            DropColumn("Sistem.Kullanicilar", "EhliyetArka");
            DropColumn("Sistem.Kullanicilar", "EhliyetOn");
            DropColumn("Sistem.Kullanicilar", "VoyagerRozet");
            DropColumn("Sistem.Kullanicilar", "Rutbesi");
            DropColumn("Sistem.Kullanicilar", "Kangrubu");
            DropColumn("Sistem.Kullanicilar", "DogumTarihi");
            DropTable("dbo.Motosiklets");
        }
    }
}
