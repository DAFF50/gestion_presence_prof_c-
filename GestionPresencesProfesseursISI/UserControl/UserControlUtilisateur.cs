using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    public partial class UserControlUtilisateur : UserControl
    {
        DbPresence db = new DbPresence();
        private bool Isvalid = true;
        public UserControlUtilisateur()
        {
            InitializeComponent();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void UserControlUtilisateur_Load(object sender, EventArgs e)
        {
            refresh();
            effacer();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            if (!(comboBoxRole.Text == "Sélectionner" || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtEmail.Text)))
            {
                if (Isvalid) {
                    try
                    {
                        Notification notification = new Notification();
                        Users users = new Users();
                        users.Nom = txtNom.Text;
                        users.Prenom = txtPrenom.Text;
                        users.Email = txtEmail.Text;
                        string PasswordHasher = BCrypt.Net.BCrypt.HashPassword("passer");
                        users.Password = PasswordHasher;
                        users.Role = comboBoxRole.Text;
                        db.Users.Add(users);
                        int changes = db.SaveChanges();
                        string sujet = EmailTemplate.GenerateEmailSubject();
                        string message = EmailTemplate.GenerateEmailBody(users.FullName, users.Email);
                        EmailService.SendEmail(users.Email, sujet, message);
                        notification.Message = "Votre compte à été créer avec succés";
                        notification.date_envoi = DateTime.Now;
                        notification.Users = db.Users.FirstOrDefault(u => u.Email == users.Email);
                        notification.IdDestinataire = notification.Users.Id;
                        db.Notification.Add(notification);
                        db.SaveChanges();
                        if (changes != 0)
                        {
                            MessageBox.Show("Utilisateur ajoutée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                            effacer();
                        }
                    }
                    catch (SmtpException smtpEx)
                    {
                        MessageBox.Show($"Erreur SMTP : {smtpEx.StatusCode}\n{smtpEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur d'envoi de l'e-mail : " + ex.Message);
                    }
                   
                }
                
            }
           
        }
        private void effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtEmail.Text = string.Empty;
            comboBoxRole.Text = "Sélectionner";
            UsersSelected = null;
        }

        private void refresh()
        {
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = db.Users.Select(u => new { u.Id, u.Nom, u.Prenom, u.Email, u.Role }).ToList();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Isvalid = false;
                errorProvider1.SetError(txtEmail, "L'email est obligatoire!");
            }else if (!Regex.IsMatch(email, emailPattern)){

                Isvalid = false;
                errorProvider1.SetError(txtEmail, "Veuillez entrer une adresse e-mail valide !");
            }
            else
            {
                Isvalid = true;
                errorProvider1.SetError(txtEmail, "");
            }
            
        }
        Users UsersSelected = null;
        private void dataGridViewUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var Users = db.Users.ToList();
            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            if (e.RowIndex >= 0 && e.RowIndex < Users.Count)
            {
                UsersSelected = Users[e.RowIndex];
                txtNom.Text = UsersSelected.Nom;
                txtPrenom.Text = UsersSelected.Prenom;
                txtEmail.Text = UsersSelected.Email;
                comboBoxRole.Text = UsersSelected.Role;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (UsersSelected != null)
            {

                DialogResult result = MessageBox.Show("Voulez vous vraiment modifier les informations de cet utilisaeur", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    UsersSelected.Nom = txtNom.Text;
                    UsersSelected.Prenom = txtPrenom.Text;
                    UsersSelected.Email = txtEmail.Text;
                    UsersSelected.Role = comboBoxRole.Text;
                    string PasswordHasher = BCrypt.Net.BCrypt.HashPassword("passer");
                    UsersSelected.Password = PasswordHasher;
                    db.SaveChanges();
                    UsersSelected = null;
                    effacer();
                    MessageBox.Show("Information de l'utilisateur modifiée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un utilisateur", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (UsersSelected != null)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer cet utilisateur", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.Users.Remove(UsersSelected);
                    db.SaveChanges();
                    UsersSelected = null;
                    MessageBox.Show("Utilisateur supprimé avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    effacer();
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un utilisateur", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNom.Text))
            {
                
                errorProvider2.SetError(txtNom, "Le nom est obligatoire!");
            }
            else
            {
                
                errorProvider2.SetError(txtNom, "");
            }
        }

        private void txtPrenom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrenom.Text))
            {
               
                errorProvider3.SetError(txtPrenom, "Le prénom est obligatoire!");

            }
            else
            {
                
                errorProvider3.SetError(txtPrenom, "");
            }
        }

        private void comboBoxRole_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxRole.Text == "Sélectionner")
            {
                
                errorProvider4.SetError(comboBoxRole, "La sélection du rôle est obligatoire");
            }
            else
            {
                
                errorProvider4.SetError(comboBoxRole, "");
            }
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            effacer();
        }
    }
}
