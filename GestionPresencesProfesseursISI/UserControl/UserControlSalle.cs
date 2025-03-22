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
    public partial class UserControlSalle : UserControl
    {
        DbPresence db = new DbPresence();
        public UserControlSalle()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void UserControlSalle_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtsalle.Text))
            {
                Salle salle = new Salle();
                salle.Libelle = txtsalle.Text;
                db.Salle.Add(salle);
                int changes = db.SaveChanges();
                if (changes != 0)
                {
                    MessageBox.Show("Salle ajoutée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsalle.Text = string.Empty;
                    refresh();
                }
            }
        }

        private void refresh()
        {
            
            
                dataGridViewSalle.DataSource = null;
                dataGridViewSalle.DataSource = db.Salle.ToList();
            
        }
        Salle SalleSelected = null;

        private void dataGridViewSalle_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                var Salles = db.Salle.ToList();
                if(e.RowIndex >= 0 &&  e.RowIndex < Salles.Count)
                {
                    SalleSelected = Salles[e.RowIndex];
                    txtsalle.Text = SalleSelected.Libelle;
                    
                }
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (SalleSelected != null) {
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer cette salle", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.Salle.Remove(SalleSelected);
                    db.SaveChanges();
                    SalleSelected = null;
                    MessageBox.Show("Salle supprimée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                } 
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une salle", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SalleSelected != null)
            {

                DialogResult result = MessageBox.Show("Voulez vous vraiment modifier cette salle", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SalleSelected.Libelle = txtsalle.Text;
                    db.SaveChanges();
                    SalleSelected = null;
                    txtsalle.Text = string.Empty;
                    MessageBox.Show("Salle modifiée avec succés", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }


            }
            else
            {
                MessageBox.Show("Veuillez selectionner une salle", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtsalle.Text = string.Empty ;
        }

        private void txtsalle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsalle.Text))
            {

                errorProvider1.SetError(txtsalle, "Le nom de la salle est obligatoire!");
            }
            else
            {

                errorProvider1.SetError(txtsalle, "");
            }
        }
    }
}
