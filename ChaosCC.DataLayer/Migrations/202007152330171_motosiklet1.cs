namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class motosiklet1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Motosiklets", newName: "Motosikletler");
            MoveTable(name: "dbo.Motosikletler", newSchema: "Kulup");
            DropForeignKey("Chaos.Devamsizliklar", "EtkinlikId", "Chaos.Etkinlikler");
            DropForeignKey("Chaos.Devamsizliklar", "KullaniciId", "Sistem.Kullanicilar");
            DropForeignKey("dbo.Motosiklets", "KullaniciId", "Sistem.Kullanicilar");
            CreateTable(
                "Kulup.Markalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 50),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Kulup.Modeller",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkaId = c.Int(nullable: false),
                        Adi = c.String(nullable: false, maxLength: 50),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Kulup.Markalar", t => t.MarkaId)
                .Index(t => t.MarkaId);
            
            AddColumn("Kulup.Motosikletler", "MarkaId", c => c.Int(nullable: false));
            AddColumn("Kulup.Motosikletler", "ModelId", c => c.Int(nullable: false));
            AddColumn("Kulup.Motosikletler", "SayacKM", c => c.Int(nullable: false));
            AddColumn("Kulup.Motosikletler", "Plaka", c => c.String());
            CreateIndex("Kulup.Motosikletler", "MarkaId");
            CreateIndex("Kulup.Motosikletler", "ModelId");
            AddForeignKey("Kulup.Motosikletler", "MarkaId", "Kulup.Markalar", "Id");
            AddForeignKey("Kulup.Motosikletler", "ModelId", "Kulup.Modeller", "Id");
            AddForeignKey("Chaos.Devamsizliklar", "EtkinlikId", "Chaos.Etkinlikler", "Id");
            AddForeignKey("Chaos.Devamsizliklar", "KullaniciId", "Sistem.Kullanicilar", "Id");
            AddForeignKey("Kulup.Motosikletler", "KullaniciId", "Sistem.Kullanicilar", "Id");
            DropColumn("Kulup.Motosikletler", "Marka");
            DropColumn("Kulup.Motosikletler", "Model");
        }
        
        public override void Down()
        {
            AddColumn("Kulup.Motosikletler", "Model", c => c.String());
            AddColumn("Kulup.Motosikletler", "Marka", c => c.String());
            DropForeignKey("Kulup.Motosikletler", "KullaniciId", "Sistem.Kullanicilar");
            DropForeignKey("Chaos.Devamsizliklar", "KullaniciId", "Sistem.Kullanicilar");
            DropForeignKey("Chaos.Devamsizliklar", "EtkinlikId", "Chaos.Etkinlikler");
            DropForeignKey("Kulup.Motosikletler", "ModelId", "Kulup.Modeller");
            DropForeignKey("Kulup.Motosikletler", "MarkaId", "Kulup.Markalar");
            DropForeignKey("Kulup.Modeller", "MarkaId", "Kulup.Markalar");
            DropIndex("Kulup.Motosikletler", new[] { "ModelId" });
            DropIndex("Kulup.Motosikletler", new[] { "MarkaId" });
            DropIndex("Kulup.Modeller", new[] { "MarkaId" });
            DropColumn("Kulup.Motosikletler", "Plaka");
            DropColumn("Kulup.Motosikletler", "SayacKM");
            DropColumn("Kulup.Motosikletler", "ModelId");
            DropColumn("Kulup.Motosikletler", "MarkaId");
            DropTable("Kulup.Modeller");
            DropTable("Kulup.Markalar");
            AddForeignKey("dbo.Motosiklets", "KullaniciId", "Sistem.Kullanicilar", "Id", cascadeDelete: true);
            AddForeignKey("Chaos.Devamsizliklar", "KullaniciId", "Sistem.Kullanicilar", "Id", cascadeDelete: true);
            AddForeignKey("Chaos.Devamsizliklar", "EtkinlikId", "Chaos.Etkinlikler", "Id", cascadeDelete: true);
            MoveTable(name: "Kulup.Motosikletler", newSchema: "dbo");
            RenameTable(name: "dbo.Motosikletler", newName: "Motosiklets");
        }
    }
}
