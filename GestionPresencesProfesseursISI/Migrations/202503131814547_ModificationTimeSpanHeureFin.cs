namespace GestionPresencesProfesseursISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationTimeSpanHeureFin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cours", "heure_début", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Cours", "heure_fin", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cours", "heure_fin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cours", "heure_début", c => c.DateTime(nullable: false));
        }
    }
}
