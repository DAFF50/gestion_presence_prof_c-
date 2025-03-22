using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    
    public partial class UserControlNotification : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlNotification()
        {
            InitializeComponent();
        }

        private void UserControlNotification_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridViewNotification.DataSource = db.Notification.Select(n => new {Id = n.Id, Message = n.Message, Destinataire = (n.Users.Prenom + " " + n.Users.Nom), Date_Envoie = n.date_envoi}).ToList();
        }

        private void dataGridViewNotification_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewNotification_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dataGridViewNotification_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
