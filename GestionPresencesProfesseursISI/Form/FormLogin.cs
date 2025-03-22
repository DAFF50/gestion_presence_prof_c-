using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    public partial class FormLogin : Form
    {
        DbPresence db = new DbPresence();
        public FormLogin()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtEmail.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            txtPassword.ForeColor = Color.Black;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void textBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtEmail.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(checkBox1.Checked))
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar=false ;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public static class SessionUtisateur
        {
            public static string role { get; set; }
            public static int Id { get; set; }
            
        }
        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            
            FormLoading FRM = new FormLoading();
            FRM.Show(this);
            var Users = await Task.Run(() => db.Users.AsNoTracking().FirstOrDefault(u => u.Email == txtEmail.Text));
            FRM.Close();
            if (Users != null && BCrypt.Net.BCrypt.Verify(txtPassword.Text, Users.Password))
            {
                SessionUtisateur.role = Users.Role;
                SessionUtisateur.Id = Users.Id;
                if (txtPassword.Text == "passer") { 
                       FormManager.ShowFormNewPassword();                
                }
                else
                {
                    FormManager.ShowFormHome();
                    txtEmail.Clear();
                    txtPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("Identifiant incorrect", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnQuitter_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez vous vraiment quitter l'application", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void lnkPasswordOublié_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.ShowFormResetRequest();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez vous vraiment quittez l'application?", "Avertissemnt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                Application.ExitThread();
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

            if(!Regex.IsMatch(email, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Veuillez entrer une adresse e-mail valide !");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
                e.Cancel = false;
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
