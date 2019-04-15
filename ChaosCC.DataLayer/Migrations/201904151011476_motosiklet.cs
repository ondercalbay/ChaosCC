namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class motosiklet : DbMigration
    {
        public override void Up()
        {
            DropTable("Chaos.KilometreBilgileri");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
