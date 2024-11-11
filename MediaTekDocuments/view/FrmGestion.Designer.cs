
namespace MediaTekDocuments.view
{
    partial class FrmGestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxrechercher = new System.Windows.Forms.GroupBox();
            this.cbxLivres = new System.Windows.Forms.ComboBox();
            this.btnrechercher = new System.Windows.Forms.Button();
            this.dgvCommandesListe = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpublic = new System.Windows.Forms.TextBox();
            this.txtrayon = new System.Windows.Forms.TextBox();
            this.txttitre = new System.Windows.Forms.TextBox();
            this.txtauteur = new System.Windows.Forms.TextBox();
            this.txtcollection = new System.Windows.Forms.TextBox();
            this.txtgenre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbdetails = new System.Windows.Forms.GroupBox();
            this.txtcommande = new System.Windows.Forms.TextBox();
            this.btnajout = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpcmd = new System.Windows.Forms.DateTimePicker();
            this.txtnbexemplaire = new System.Windows.Forms.TextBox();
            this.txtmontant = new System.Windows.Forms.TextBox();
            this.gbxrechercher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandesListe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbdetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxrechercher
            // 
            this.gbxrechercher.Controls.Add(this.cbxLivres);
            this.gbxrechercher.Controls.Add(this.btnrechercher);
            this.gbxrechercher.Location = new System.Drawing.Point(12, 12);
            this.gbxrechercher.Name = "gbxrechercher";
            this.gbxrechercher.Size = new System.Drawing.Size(367, 93);
            this.gbxrechercher.TabIndex = 0;
            this.gbxrechercher.TabStop = false;
            this.gbxrechercher.Text = "Rechercher";
            // 
            // cbxLivres
            // 
            this.cbxLivres.FormattingEnabled = true;
            this.cbxLivres.Location = new System.Drawing.Point(6, 34);
            this.cbxLivres.Name = "cbxLivres";
            this.cbxLivres.Size = new System.Drawing.Size(219, 21);
            this.cbxLivres.TabIndex = 2;
            this.cbxLivres.SelectedIndexChanged += new System.EventHandler(this.cbxLivres_SelectedIndexChanged);
            // 
            // btnrechercher
            // 
            this.btnrechercher.Location = new System.Drawing.Point(249, 32);
            this.btnrechercher.Name = "btnrechercher";
            this.btnrechercher.Size = new System.Drawing.Size(75, 23);
            this.btnrechercher.TabIndex = 1;
            this.btnrechercher.Text = "Rechercher";
            this.btnrechercher.UseVisualStyleBackColor = true;
            this.btnrechercher.Click += new System.EventHandler(this.btnrechercher_Click);
            // 
            // dgvCommandesListe
            // 
            this.dgvCommandesListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandesListe.Location = new System.Drawing.Point(6, 133);
            this.dgvCommandesListe.Name = "dgvCommandesListe";
            this.dgvCommandesListe.Size = new System.Drawing.Size(390, 119);
            this.dgvCommandesListe.TabIndex = 0;
            this.dgvCommandesListe.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLivres_ColumnHeaderMouseClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpublic);
            this.groupBox1.Controls.Add(this.txtrayon);
            this.groupBox1.Controls.Add(this.txttitre);
            this.groupBox1.Controls.Add(this.txtauteur);
            this.groupBox1.Controls.Add(this.txtcollection);
            this.groupBox1.Controls.Add(this.txtgenre);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvCommandesListe);
            this.groupBox1.Location = new System.Drawing.Point(12, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 267);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // txtpublic
            // 
            this.txtpublic.Location = new System.Drawing.Point(284, 58);
            this.txtpublic.Name = "txtpublic";
            this.txtpublic.Size = new System.Drawing.Size(100, 20);
            this.txtpublic.TabIndex = 12;
            // 
            // txtrayon
            // 
            this.txtrayon.Location = new System.Drawing.Point(284, 84);
            this.txtrayon.Name = "txtrayon";
            this.txtrayon.Size = new System.Drawing.Size(100, 20);
            this.txtrayon.TabIndex = 11;
            // 
            // txttitre
            // 
            this.txttitre.Location = new System.Drawing.Point(68, 55);
            this.txttitre.Name = "txttitre";
            this.txttitre.Size = new System.Drawing.Size(100, 20);
            this.txttitre.TabIndex = 10;
            // 
            // txtauteur
            // 
            this.txtauteur.Location = new System.Drawing.Point(68, 29);
            this.txtauteur.Name = "txtauteur";
            this.txtauteur.Size = new System.Drawing.Size(100, 20);
            this.txtauteur.TabIndex = 9;
            // 
            // txtcollection
            // 
            this.txtcollection.Location = new System.Drawing.Point(68, 81);
            this.txtcollection.Name = "txtcollection";
            this.txtcollection.Size = new System.Drawing.Size(100, 20);
            this.txtcollection.TabIndex = 8;
            // 
            // txtgenre
            // 
            this.txtgenre.Location = new System.Drawing.Point(284, 32);
            this.txtgenre.Name = "txtgenre";
            this.txtgenre.Size = new System.Drawing.Size(100, 20);
            this.txtgenre.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Rayon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Genre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Public";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Collection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Titre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Auteur";
            // 
            // gbdetails
            // 
            this.gbdetails.Controls.Add(this.txtcommande);
            this.gbdetails.Controls.Add(this.btnajout);
            this.gbdetails.Controls.Add(this.label10);
            this.gbdetails.Controls.Add(this.label9);
            this.gbdetails.Controls.Add(this.label8);
            this.gbdetails.Controls.Add(this.label7);
            this.gbdetails.Controls.Add(this.dtpcmd);
            this.gbdetails.Controls.Add(this.txtnbexemplaire);
            this.gbdetails.Controls.Add(this.txtmontant);
            this.gbdetails.Location = new System.Drawing.Point(435, 125);
            this.gbdetails.Name = "gbdetails";
            this.gbdetails.Size = new System.Drawing.Size(353, 263);
            this.gbdetails.TabIndex = 2;
            this.gbdetails.TabStop = false;
            this.gbdetails.Text = "Details d\'une commande";
            // 
            // txtcommande
            // 
            this.txtcommande.Location = new System.Drawing.Point(129, 29);
            this.txtcommande.Name = "txtcommande";
            this.txtcommande.Size = new System.Drawing.Size(100, 20);
            this.txtcommande.TabIndex = 9;
            // 
            // btnajout
            // 
            this.btnajout.Location = new System.Drawing.Point(254, 225);
            this.btnajout.Name = "btnajout";
            this.btnajout.Size = new System.Drawing.Size(75, 23);
            this.btnajout.TabIndex = 8;
            this.btnajout.Text = "Ajouter";
            this.btnajout.UseVisualStyleBackColor = true;
            this.btnajout.Click += new System.EventHandler(this.btnajout_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Nombre d\'exemplaire";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Montant";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Date de commande";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Numéro de commande";
            // 
            // dtpcmd
            // 
            this.dtpcmd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpcmd.Location = new System.Drawing.Point(129, 73);
            this.dtpcmd.Name = "dtpcmd";
            this.dtpcmd.Size = new System.Drawing.Size(100, 20);
            this.dtpcmd.TabIndex = 3;
            // 
            // txtnbexemplaire
            // 
            this.txtnbexemplaire.Location = new System.Drawing.Point(129, 155);
            this.txtnbexemplaire.Name = "txtnbexemplaire";
            this.txtnbexemplaire.Size = new System.Drawing.Size(100, 20);
            this.txtnbexemplaire.TabIndex = 2;
            // 
            // txtmontant
            // 
            this.txtmontant.Location = new System.Drawing.Point(129, 114);
            this.txtmontant.Name = "txtmontant";
            this.txtmontant.Size = new System.Drawing.Size(100, 20);
            this.txtmontant.TabIndex = 1;
            // 
            // FrmGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbdetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxrechercher);
            this.Name = "FrmGestion";
            this.Text = "FrmGestion";
            this.gbxrechercher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandesListe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbdetails.ResumeLayout(false);
            this.gbdetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxrechercher;
        private System.Windows.Forms.DataGridView dgvCommandesListe;
        private System.Windows.Forms.Button btnrechercher;
        private System.Windows.Forms.ComboBox cbxLivres;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpublic;
        private System.Windows.Forms.TextBox txtrayon;
        private System.Windows.Forms.TextBox txttitre;
        private System.Windows.Forms.TextBox txtauteur;
        private System.Windows.Forms.TextBox txtcollection;
        private System.Windows.Forms.TextBox txtgenre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbdetails;
        private System.Windows.Forms.Button btnajout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpcmd;
        private System.Windows.Forms.TextBox txtnbexemplaire;
        private System.Windows.Forms.TextBox txtmontant;
        private System.Windows.Forms.TextBox txtcommande;
    }
}