namespace GestionPresencesProfesseursISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation_db_gestion_presence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        heure_début = c.DateTime(nullable: false),
                        heure_fin = c.DateTime(nullable: false),
                        IdSalle = c.Int(nullable: false),
                        IdProfesseur = c.Int(nullable: false),
                        Salle_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salles", t => t.Salle_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Salle_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emargements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        statut = c.String(),
                        IdProfesseur = c.Int(nullable: false),
                        IdCours = c.Int(nullable: false),
                        Cours_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cours", t => t.Cours_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Cours_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        IdDestinataire = c.Int(nullable: false),
                        date_envoi = c.DateTime(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Emargements", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Emargements", "Cours_Id", "dbo.Cours");
            DropForeignKey("dbo.Cours", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Cours", "Salle_Id", "dbo.Salles");
            DropIndex("dbo.Notifications", new[] { "Users_Id" });
            DropIndex("dbo.Emargements", new[] { "Users_Id" });
            DropIndex("dbo.Emargements", new[] { "Cours_Id" });
            DropIndex("dbo.Cours", new[] { "Users_Id" });
            DropIndex("dbo.Cours", new[] { "Salle_Id" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Emargements");
            DropTable("dbo.Users");
            DropTable("dbo.Salles");
            DropTable("dbo.Cours");
        }
    }
}
