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
    public partial class FormOTPVerification : Form
    {
        public FormOTPVerification()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            FormManager.ShowFormNewPassword();
        }

        private void FormOTPVerification_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
