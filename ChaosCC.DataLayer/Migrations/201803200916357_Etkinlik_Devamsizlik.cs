namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Etkinlik_Devamsizlik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chaos.Devamsizliklar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtkinlikId = c.Int(nullable: false),
                        KullaniciId = c.Int(nullable: false),
                        Geldi = c.Boolean(nullable: false),
                        Aciklama = c.String(),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Chaos.Etkinlikler", t => t.EtkinlikId, cascadeDelete: true)
                .ForeignKey("Sistem.Kullanicilar", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.EtkinlikId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "Chaos.Etkinlikler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Yer = c.String(nullable: false, maxLength: 1000),
                        EtlinlikTuru = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Aciklama = c.String(maxLength: 4000),
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
            DropForeignKey("Chaos.Devamsizliklar", "KullaniciId", "Sistem.Kullanicilar");
            DropForeignKey("Chaos.Devamsizliklar", "EtkinlikId", "Chaos.Etkinlikler");
            DropIndex("Chaos.Devamsizliklar", new[] { "KullaniciId" });
            DropIndex("Chaos.Devamsizliklar", new[] { "EtkinlikId" });
            DropTable("Chaos.Etkinlikler");
            DropTable("Chaos.Devamsizliklar");
        }
    }
}
