using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    public partial class UserControlEmargementAdmin : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlEmargementAdmin()
        {
            InitializeComponent();
            tabPage1.Text = "Emargement en attente";
            tabPage2.Text = "Historique des émargements";
        }

        private void UserControlEmargement_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridViewEmargement.DataSource = null;
            dataGridViewEmargement.DataSource = db.Emargement.Where(E => E.statut == "En attente").Select(E => new { E.Id, E.date, E.statut, Professeur = E.Users.Prenom + " " + E.Users.Nom, Cours = E.Cours.Nom}).ToList();
            dataGridViewHistorique.DataSource = null;
            dataGridViewHistorique.DataSource = db.Emargement.Select(E => new { E.Id, E.date, E.statut, Professeur = E.Users.Prenom + " " + E.Users.Nom, Cours = E.Cours.Nom }).ToList();
        }

        Emargement emargementSelected = null;
       
       
        private void btnhistorique_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnValider_Click_1(object sender, EventArgs e)
        {
            if (emargementSelected != null)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment Validé le status de présence de ce professeur", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Notification notification = new Notification();
                    emargementSelected.statut = "Présent";
                    string fullNameProf = emargementSelected.Users.FullName;
                    string emailProf = emargementSelected.Users.Email;
                    string nomCours = emargementSelected.Cours.Nom;
                    string salle = emargementSelected.Cours.Salle.Libelle;
                    string sujet = EmailTemplate.GenerateEmailSubjectEmargementValide();
                    string message = EmailTemplate.GenerateEmailBodyEmargementValide(fullNameProf, nomCours, salle, emargementSelected.Cours.heure_début.ToString(@"hh\:mm"), emargementSelected.Cours.heure_fin.ToString(@"hh\:mm"));
                    EmailService.SendEmail(emailProf, sujet, message);
                    notification.Message = "Émargement validé avec succés - ISI";
                    notification.date_envoi = DateTime.Now;
                    notification.Users = emargementSelected.Users;
                    notification.IdDestinataire = notification.Users.Id;
                    db.Notification.Add(notification);
                    int changes = db.SaveChanges();
                    if (changes > 0)
                    {
                        emargementSelected = null;
                        MessageBox.Show("Validation reussi avec succés!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un émargement", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmargement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewEmargement_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer l'ID de l'émargement sélectionné dans la DataGridView
                int idSelected = Convert.ToInt32(dataGridViewEmargement.Rows[e.RowIndex].Cells["Id"].Value);
                emargementSelected = db.Emargement.Include(E => E.Cours).Include(E => E.Users).FirstOrDefault(E => E.Id == idSelected);
                db.Entry(emargementSelected.Cours).Reference(E => E.Salle).Load();
            }
        }
    }
}
