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
using static GestionPresencesProfesseursISI.FormLogin;

namespace GestionPresencesProfesseursISI
{
    public partial class UserControlEmargementProf : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlEmargementProf()
        {
            InitializeComponent();
        }

        private void UserControl1EmargementProf_Load(object sender, EventArgs e)
        {
            refresh();
            var coursNonEmarges = db.Cours.Where(c => c.IdProfesseur == SessionUtisateur.Id && !db.Emargement.Any(E => E.IdCours == c.Id)).ToList();
            comboBoxCours.DataSource = coursNonEmarges;
            comboBoxCours.DisplayMember = "Nom";
            comboBoxCours.ValueMember = "Id";
        }

        private void refresh()
        {
            
            dataGridViewEmargement.DataSource = null;
            dataGridViewEmargement.DataSource = db.Emargement.Where(E => E.IdProfesseur == SessionUtisateur.Id).Select(E => new { E.date, E.statut, Professeur = E.Users.Prenom + " " + E.Users.Nom, Cours = E.Cours.Nom }).ToList();
        }

        private void btnEmarge_Click(object sender, EventArgs e)
        {
            if(comboBoxCours.DataSource != null)
            {
                    Emargement emargement = new Emargement();
                    Notification notification = new Notification();
                    emargement.date = DateTime.Now;
                    emargement.statut = "En attente";
                    emargement.IdProfesseur = SessionUtisateur.Id;
                    emargement.Users = db.Users.FirstOrDefault(u => u.Id == SessionUtisateur.Id);
                    emargement.IdCours = (int)comboBoxCours.SelectedValue;
                    emargement.Cours = db.Cours.Include(c => c.Salle).FirstOrDefault(c => c.Id == emargement.IdCours);
                    string fullNameProf = emargement.Users.FullName;
                    string emailProf = emargement.Users.Email;
                    string nomCours = emargement.Cours.Nom;
                    var salle = emargement.Cours.Salle.Libelle;
                    string sujet = EmailTemplate.GenerateEmailSubjectEmargementEnAttente();
                    string message = EmailTemplate.GenerateEmailBodyEmargementEnAttente(fullNameProf, nomCours, salle, emargement.Cours.heure_début.ToString(@"hh\:mm"), emargement.Cours.heure_fin.ToString(@"hh\:mm"));
                    EmailService.SendEmail(emailProf, sujet, message);
                    notification.Message = "Émargement en attente de validation - ISI";
                    notification.date_envoi = DateTime.Now;
                    notification.Users = emargement.Users;
                    notification.IdDestinataire = notification.Users.Id;
                    db.Notification.Add(notification);
                    db.SaveChanges();
                    db.Emargement.Add(emargement);
                    int changes = db.SaveChanges();
                    if (changes != 0)
                    {
                        MessageBox.Show("Votre émargement est lancé avec succés! En attente de validation, merci!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxCours.Text = "Sélectionner";
                        refresh();
                    }
            }
            else
            {
                MessageBox.Show("Aucun cours à émargé!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
