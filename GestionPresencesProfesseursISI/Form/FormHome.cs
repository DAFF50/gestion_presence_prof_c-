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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            UserControlUtilisateur uc = new UserControlUtilisateur();
            ShowPage(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void FormHome_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez vous vous déconectez?", "Avertissemnt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse == DialogResult.Yes)
            {
                
                FormManager.ShowFormLogin();
            }
        }

        private void btnDeconnexion_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void ShowPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserControlUtilisateur uc = new UserControlUtilisateur();
            ShowPage(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControlCours uc = new UserControlCours();
            ShowPage(uc);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if(SessionUtisateur.role == "Professeur")
            {
                UserControlEmargementProf userControlEmargementProf = new UserControlEmargementProf();
                ShowPage(userControlEmargementProf);

            }
            else
            {
                UserControlEmargementAdmin userControlEmargement = new UserControlEmargementAdmin();
                ShowPage(userControlEmargement);
            }
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            UserControlRapportStatistique uc = new UserControlRapportStatistique();
            ShowPage(uc);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            UserControlSalle userControlSalle = new UserControlSalle();
            ShowPage(userControlSalle);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserControlNotification userControlNotification = new UserControlNotification();    
            ShowPage(userControlNotification);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserControlParametre userControlParametre = new UserControlParametre();
            ShowPage(userControlParametre);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UserControlAideSupport userControlAide = new UserControlAideSupport();
            ShowPage(userControlAide);
        }

        private void FormHome_Activated(object sender, EventArgs e)
        {
            if (SessionUtisateur.role == "Professeur")
            {
                button1.Enabled = false;
                button5.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button5.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void FormHome_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) // Vérifier que le formulaire est visible
            {
                if (SessionUtisateur.role == "Professeur")
                {
                    UserControlEmargementProf userControlEmargementProf = new UserControlEmargementProf();
                    ShowPage(userControlEmargementProf);

                }
                else
                {
                    UserControlUtilisateur uc = new UserControlUtilisateur();
                    ShowPage(uc);
                }
            }
        }

    }
}
