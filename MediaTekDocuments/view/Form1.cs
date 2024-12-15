using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using MediaTekDocuments.controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaTekDocuments.view
{
    public partial class Form1 : Form
    {
        private readonly FrmgestionController frmgestionController;
        public Form1()
        {
            InitializeComponent();
            frmgestionController = new FrmgestionController();
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            string pseudo = txtutilisateur.Text;
            string password = txtmdp.Text;

            try
            {
                Utilisateur utilisateur = new Utilisateur(pseudo, password);
                List<Service> services = frmgestionController.GetService(utilisateur);

                if (services != null && services.Count > 0)
                {
                    Service service = services.FirstOrDefault();

                    if (service != null)
                    {
                        switch (service.IdService)
                        {
                            case 1:
                                FrmMediatek frmAdmin = new FrmMediatek(service);
                                this.Hide();
                                frmAdmin.ShowDialog();
                                
                                break;

                            case 2:
                                FrmMediatek frmPret = new FrmMediatek(service);
                                frmPret.SetLimitedAccess(); 
                                this.Hide();
                                frmPret.ShowDialog();
                                this.Close();
                                break;

                            case 3:
                                MessageBox.Show("Vous n'avez pas les droits nécessaires pour accéder à cette application.", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                                break;

                            case 4:
                                FrmMediatek frmAdminFull = new FrmMediatek(service);
                                this.Hide();
                                frmAdminFull.ShowDialog();
                                this.Close();
                                break;

                            default:
                                MessageBox.Show("Type de service inconnu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    
}
