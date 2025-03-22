using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;

namespace GestionPresencesProfesseursISI
{
    public partial class UserControlRapportStatistique : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlRapportStatistique()
        {
            InitializeComponent();
            tabPage1.Text = "Exportation document";
            tabPage2.Text = "Graphiques";
        }
        


        private void btnConnexion_Click_1(object sender, EventArgs e)
        {
            string format = comboBoxFormat.Text;
            var emargements = db.Emargement.Include(E => E.Users).Include(C => C.Cours).ToList();
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string excelFilePath = Path.Combine(downloadsPath, "emargements.xlsx");
            string pdflFilePath = Path.Combine(downloadsPath, "emargements.pdf");
            if (format == "EXCEL")
            {
                Emargement.ExportToExcel(emargements, excelFilePath);
                MessageBox.Show("Fichier excel généré dans le dossier téléchargement de votre machine avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (format == "PDF")
            {
                Emargement.ExportToPDF(emargements, pdflFilePath);
                MessageBox.Show("Fichier pdf généré dans le dossier téléchargement de votre machine avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Veuillez choisir le format d'exportation", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
