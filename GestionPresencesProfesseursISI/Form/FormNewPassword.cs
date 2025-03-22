using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GestionPresencesProfesseursISI.FormLogin;

namespace GestionPresencesProfesseursISI
{
    public partial class FormNewPassword : Form
    {
        public FormNewPassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if(txtpassword1.Text == txtpassword2.Text)
            {
                using(var db = new DbPresence())
                {
                    var userSelected = db.Users.FirstOrDefault(u => u.Id == SessionUtisateur.Id);
                    string PasswordHasher = BCrypt.Net.BCrypt.HashPassword(txtpassword2.Text);
                    userSelected.Password = PasswordHasher;
                    int changes = db.SaveChanges();
                    if (changes != 0)
                    {
                        MessageBox.Show("Nouveau mot de passe définie avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormManager.ShowFormHome();
                    }
                   
                }
                FormManager.ShowFormLogin();
            }
            else
            {
                MessageBox.Show("Les mots de passe doivent être identique", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNewPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez vous annuler l'opération et retourner à la page de connexion", "Avertissemnt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                FormManager.ShowFormLogin();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormNewPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
