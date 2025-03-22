using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class DbPresence : DbContext
    {
        public DbPresence() : base("connexioniage") { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Salle> Salle { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Emargement> Emargement { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
