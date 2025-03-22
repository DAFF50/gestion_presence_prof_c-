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
    public partial class UserControlCours : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlCours()
        {
            InitializeComponent();
           
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControlCours_Load(object sender, EventArgs e)
        {
            refresh();
            effacer();
            comboBoxSalle.DataSource = db.Salle.ToList();
            comboBoxSalle.DisplayMember = "Libelle";
            comboBoxSalle.ValueMember = "Id";

            comboBoxProfesseur.DataSource = db.Users.Where(u => u.Role == "Professeur").ToList();
            comboBoxProfesseur.DisplayMember = "FullName";
            comboBoxProfesseur.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            effacer();   
        }

       

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            if (!(string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtDescription.Text)))
            {
                Notification notification = new Notification();
                Cours cours = new Cours();
                cours.Nom = txtNom.Text;
                cours.Description = txtDescription.Text;
                int hd = dateTimePickerDebut.Value.Hour;
                int md = dateTimePickerDebut.Value.Minute;
                int sd = dateTimePickerDebut.Value.Second;
                cours.heure_début = new TimeSpan(hd, md, sd);
                int hf = dateTimePickerFin.Value.Hour;
                int mf = dateTimePickerFin.Value.Minute;
                int sf = dateTimePickerFin.Value.Second;
                cours.heure_fin = new TimeSpan(hf, mf, sf);
                cours.IdSalle = (int)comboBoxSalle.SelectedValue;
                cours.IdProfesseur = (int)comboBoxProfesseur.SelectedValue;
                cours.Salle = db.Salle.FirstOrDefault(Salle => Salle.Id == cours.IdSalle);
                cours.Users = db.Users.FirstOrDefault(u => u.Id == cours.IdProfesseur);
                bool conflitSalle = db.Cours.Any(c => c.heure_début <= cours.heure_début && cours.heure_début <= c.heure_fin && (c.IdSalle == cours.IdSalle));
                bool conflitProf = db.Cours.Any(c => c.heure_début <= cours.heure_début && cours.heure_début <= c.heure_fin && (c.IdProfesseur == cours.IdProfesseur));
                if (conflitSalle)
                {
                    MessageBox.Show("La salle est déjà occupée pendant cette plage horaire, Veuillez choisir une autre salle ou une autre plage horaire.", "Conflit d'horaire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (conflitProf)
                {
                    MessageBox.Show("Le professeur est déjà occupé pendant cette plage horaire., Veuillez choisir un autre professeur ou une autre plage horaire.", "Conflit d'horaire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string FullNameProf = cours.Users.FullName;
                string emailProf = cours.Users.Email;
                string sujet = EmailTemplate.GenerateEmailSubjectAddcours();
                string message = EmailTemplate.GenerateEmailBodyAddCours(FullNameProf, cours.Nom, cours.Salle.Libelle, cours.heure_début.ToString(@"hh\:mm"), cours.heure_fin.ToString(@"hh\:mm"));
                EmailService.SendEmail(emailProf, sujet, message);
                notification.Message = "Nouvelle programmation de cours - ISI";
                notification.date_envoi = DateTime.Now;
                notification.Users = cours.Users;
                notification.IdDestinataire = notification.Users.Id;
                db.Notification.Add(notification);
                db.SaveChanges();
                db.Cours.Add(cours);
                int changes = db.SaveChanges();
                if (changes != 0)
                {
                    MessageBox.Show("Cours ajouté avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    effacer();
                    refresh();
                }
            }
        }

        private void effacer()
        {
            txtDescription.Text = string.Empty;
            txtNom.Text = string.Empty;
            CoursSelected = null;
        }

        private void refresh()
        {
            dataGridViewCours.DataSource = db.Cours.Select(c => new {Id = c.Id, NomCours = c.Nom, Description = c.Description, Heure_début = c.heure_début, Heure_Fin = c.heure_fin, Salle = c.Salle.Libelle, Professeur = c.Users.Prenom + " " + c.Users.Nom }).ToList();
        }
        Cours CoursSelected = null;
        private void dataGridViewCours_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var Cours = db.Cours.ToList();
            if (e.RowIndex >= 0 && e.RowIndex < Cours.Count)
            {
                CoursSelected = Cours[e.RowIndex];
                txtNom.Text = CoursSelected.Nom;
                txtDescription.Text = CoursSelected.Description;
                comboBoxSalle.SelectedValue = CoursSelected.Salle.Id;
                comboBoxProfesseur.SelectedValue = CoursSelected.Users.Id;
                dateTimePickerDebut.Value = DateTime.Today.Add(CoursSelected.heure_début);
                dateTimePickerFin.Value = DateTime.Today.Add(CoursSelected.heure_fin);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (CoursSelected != null)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer ce cours", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.Cours.Remove(CoursSelected);
                    db.SaveChanges();
                    CoursSelected = null;
                    MessageBox.Show("Cours supprimée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    effacer();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un cours", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (CoursSelected != null)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment modifier ce cours", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    CoursSelected.Nom = txtNom.Text;
                    CoursSelected.Description = txtDescription.Text;
                    int hd = dateTimePickerDebut.Value.Hour;
                    int md = dateTimePickerDebut.Value.Minute;
                    int sd = dateTimePickerDebut.Value.Second;
                    CoursSelected.heure_début = new TimeSpan(hd, md, sd);
                    int hf = dateTimePickerFin.Value.Hour;
                    int mf = dateTimePickerFin.Value.Minute;
                    int sf = dateTimePickerFin.Value.Second;
                    CoursSelected.heure_fin = new TimeSpan(hf, mf, sf);
                    CoursSelected.IdSalle = (int)comboBoxSalle.SelectedValue;
                    CoursSelected.Salle = db.Salle.FirstOrDefault(s => s.Id == CoursSelected.IdSalle);
                    CoursSelected.IdProfesseur = (int)comboBoxProfesseur.SelectedValue;
                    CoursSelected.Users = db.Users.FirstOrDefault(u => u.Id == CoursSelected.IdProfesseur);
                    db.SaveChanges();
                    CoursSelected = null;
                    effacer();
                    MessageBox.Show("Cours modifiée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un cours", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text))
            {

                errorProvider1.SetError(txtNom, "Le nom est obligatoire!");
            }
            else
            {

                errorProvider1.SetError(txtNom, "");
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {

                errorProvider2.SetError(txtDescription, "La description est obligatoire!");
            }
            else
            {
                errorProvider2.SetError(txtDescription, "");
            }
        }
    }
}