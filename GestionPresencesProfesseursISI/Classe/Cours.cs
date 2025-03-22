using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class Cours
    {
        public Cours() { }
        public int Id {  get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public TimeSpan heure_début { get; set; }
        public TimeSpan heure_fin { get; set; }
        public int IdSalle {  get; set; }
        public int IdProfesseur {  get; set; }

        public Salle Salle { get; set; }
        public Users Users { get; set; }
    }
}
