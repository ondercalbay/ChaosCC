namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class markamadel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarkaId = c.Int(nullable: false),
                        Adi = c.String(),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markas", t => t.MarkaId, cascadeDelete: true)
                .Index(t => t.MarkaId);
            
            AddColumn("dbo.Motosiklets", "MarkaId", c => c.Int(nullable: false));
            AddColumn("dbo.Motosiklets", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Motosiklets", "MarkaId");
            CreateIndex("dbo.Motosiklets", "ModelId");
            AddForeignKey("dbo.Motosiklets", "MarkaId", "dbo.Markas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Motosiklets", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            DropColumn("dbo.Motosiklets", "Marka");
            DropColumn("dbo.Motosiklets", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Motosiklets", "Model", c => c.String());
            AddColumn("dbo.Motosiklets", "Marka", c => c.String());
            DropForeignKey("dbo.Motosiklets", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Motosiklets", "MarkaId", "dbo.Markas");
            DropForeignKey("dbo.Models", "MarkaId", "dbo.Markas");
            DropIndex("dbo.Motosiklets", new[] { "ModelId" });
            DropIndex("dbo.Motosiklets", new[] { "MarkaId" });
            DropIndex("dbo.Models", new[] { "MarkaId" });
            DropColumn("dbo.Motosiklets", "ModelId");
            DropColumn("dbo.Motosiklets", "MarkaId");
            DropTable("dbo.Models");
            DropTable("dbo.Markas");
        }
    }
}
