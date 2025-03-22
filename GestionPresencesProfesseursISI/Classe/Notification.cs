using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class Notification
    {
        public Notification() { }
        public int Id {  get; set; }
        public string Message { get; set; }
        public int IdDestinataire { get; set; }
        public Users Users { get; set; }
        public DateTime date_envoi { get; set; }

    }
}
