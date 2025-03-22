namespace GestionPresencesProfesseursISI
{
    partial class UserControlEmargementProf
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCours = new System.Windows.Forms.ComboBox();
            this.btnEmarge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewEmargement = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmargement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxCours);
            this.panel2.Controls.Add(this.btnEmarge);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(15, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1238, 265);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.label2.Location = new System.Drawing.Point(126, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(552, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Veuillez sélectionner les cours que vous devez émargés";
            // 
            // comboBoxCours
            // 
            this.comboBoxCours.FormattingEnabled = true;
            this.comboBoxCours.Items.AddRange(new object[] {
            "Présent",
            "Absent"});
            this.comboBoxCours.Location = new System.Drawing.Point(244, 79);
            this.comboBoxCours.Name = "comboBoxCours";
            this.comboBoxCours.Size = new System.Drawing.Size(232, 28);
            this.comboBoxCours.TabIndex = 15;
            // 
            // btnEmarge
            // 
            this.btnEmarge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.btnEmarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmarge.ForeColor = System.Drawing.Color.White;
            this.btnEmarge.Location = new System.Drawing.Point(131, 176);
            this.btnEmarge.Name = "btnEmarge";
            this.btnEmarge.Size = new System.Drawing.Size(178, 42);
            this.btnEmarge.TabIndex = 11;
            this.btnEmarge.Text = "Emargé";
            this.btnEmarge.UseVisualStyleBackColor = false;
            this.btnEmarge.Click += new System.EventHandler(this.btnEmarge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.label3.Location = new System.Drawing.Point(126, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mes cours";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridViewEmargement);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 328);
            this.panel1.TabIndex = 6;
            // 
            // dataGridViewEmargement
            // 
            this.dataGridViewEmargement.AllowUserToAddRows = false;
            this.dataGridViewEmargement.AllowUserToDeleteRows = false;
            this.dataGridViewEmargement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmargement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmargement.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEmargement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEmargement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmargement.EnableHeadersVisualStyles = false;
            this.dataGridViewEmargement.Location = new System.Drawing.Point(20, 53);
            this.dataGridViewEmargement.Name = "dataGridViewEmargement";
            this.dataGridViewEmargement.ReadOnly = true;
            this.dataGridViewEmargement.RowHeadersWidth = 62;
            this.dataGridViewEmargement.RowTemplate.Height = 28;
            this.dataGridViewEmargement.Size = new System.Drawing.Size(1199, 259);
            this.dataGridViewEmargement.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(182)))));
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes émargements";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UserControlEmargementProf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlEmargementProf";
            this.Size = new System.Drawing.Size(1268, 644);
            this.Load += new System.EventHandler(this.UserControl1EmargementProf_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmargement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCours;
        private System.Windows.Forms.Button btnEmarge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewEmargement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
