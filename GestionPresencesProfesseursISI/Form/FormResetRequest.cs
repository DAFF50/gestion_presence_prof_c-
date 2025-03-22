using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    public partial class FormResetRequest : Form
    {
        DbPresence db = new DbPresence();
        private bool Isvalid = true;
        public FormResetRequest()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            if (Isvalid)
            {
                var Users = db.Users.FirstOrDefault(u => u.Email == txtEmail.Text);
                if (Users != null) {
                    FormManager.ShowFormOTPVerification();

                }
                else
                {
                    MessageBox.Show("Email non trouvé!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }


        private void FormResetRequest_Load(object sender, EventArgs e)
        {

        }

        private void FormResetRequest_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Isvalid = false;
                errorProvider1.SetError(txtEmail, "L'email est obligatoire!");
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {

                Isvalid = false;
                errorProvider1.SetError(txtEmail, "Veuillez entrer une adresse e-mail valide !");
            }
            else
            {
                Isvalid = true;
                errorProvider1.SetError(txtEmail, "");
            }
        }
    }
}
