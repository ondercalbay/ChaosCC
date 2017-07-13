namespace ChaosCC.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EMailDegisti : DbMigration
    {
        public override void Up()
        {
            AddColumn("Sistem.Kullanicilar", "EPosta", c => c.String(nullable: false, maxLength: 100));
            DropColumn("Sistem.Kullanicilar", "EMail");
        }
        
        public override void Down()
        {
            AddColumn("Sistem.Kullanicilar", "EMail", c => c.String(nullable: false, maxLength: 100));
            DropColumn("Sistem.Kullanicilar", "EPosta");
        }
    }
}
