using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using MediaTekDocuments.controller;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;


namespace MediaTekDocuments.view
{
    public partial class FrmGestion : Form
    {
        private readonly BindingSource bdgLivres = new BindingSource();
        private readonly BindingSource bdgDetailCommande = new BindingSource();
        private readonly BindingSource bdgCommandes = new BindingSource();
        private readonly BindingSource bdgCommandesDocument = new BindingSource();
        private readonly BindingSource bdgSuivi = new BindingSource();
        private List<Livre> lesLivres;
        private List<CommandeDocument> lescommandedocuments = new List<CommandeDocument>();
        private List<DetailsCommande> lesDetailCommandes = new List<DetailsCommande>();
        private List<Commande> lesCommandes = new List<Commande>();
        private List<Suivi> lesSuivis = new List<Suivi>();

        private FrmgestionController frmgestionController;

        public FrmGestion()
        {
            InitializeComponent();
            frmgestionController = new FrmgestionController();
            ChargerLivresListeComplete();
            ChargerLivres();
            cbxLivres.SelectedIndex = -1;
            dgvCommandesListe.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Charge la liste complète des livres dans le DataGridView
        /// </summary>
        private void ChargerLivresListeComplete()
        {
            lesLivres = Access.GetInstance().GetAllLivres();
        }
        private void ChargerLivres()
        {
            List<Livre> livres = lesLivres;
            bdgLivres.DataSource = livres;
            cbxLivres.DataSource = bdgLivres;
            cbxLivres.DisplayMember = "Id";
            cbxLivres.ValueMember = "Id";
        }

        /// <summary>
        /// Remplit le DataGridView avec une liste de comandes
        /// </summary>
        /// <param name="commandeListes">Liste de commandes</param>
        private void RemplirCommandeListes(List<DetailsCommande> lesDetailCommandes)

        {
            if (lesDetailCommandes != null)
            {
                bdgDetailCommande.DataSource = lesDetailCommandes;
                dgvCommandesListe.DataSource = bdgDetailCommande;
                dgvCommandesListe.Columns["dateCommande"].DisplayIndex = 0;
                dgvCommandesListe.Columns["montant"].DisplayIndex = 1;
                dgvCommandesListe.Columns["nbExemplaire"].DisplayIndex = 2;
                dgvCommandesListe.Columns["etape"].DisplayIndex = 3;
                dgvCommandesListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;               
                dgvCommandesListe.Columns["idCommande"].Visible = false;
                dgvCommandesListe.Columns["idCommandeDocument"].Visible = false;
                dgvCommandesListe.Columns["idLivreDvd"].Visible = false;


            }
            else
            {
                bdgDetailCommande.DataSource = null;
            }
        }



        private void dgvLivres_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvCommandesListe.Columns[e.ColumnIndex].HeaderText;
            List<DetailsCommande> sortedList = new List<DetailsCommande>();

            switch (titreColonne)
            {
                case "idCommande":
                    sortedList = lesDetailCommandes.OrderBy(o => o.IdCommande).ToList();
                    break;
                case "idCommandeDocument":
                    sortedList = lesDetailCommandes.OrderBy(o => o.IdCommandeDocument).ToList();
                    break;
                case "etape":
                    sortedList = lesDetailCommandes.OrderBy(o => o.Etape).ToList();
                    break;
                case "nbExemplaire":
                    sortedList = lesDetailCommandes.OrderBy(o => o.NbExemplaire).ToList();
                    break;
                case "montant":
                    sortedList = lesDetailCommandes.OrderBy(o => o.Montant).ToList();
                    break;
                case "dateCommande":
                    sortedList = lesDetailCommandes.OrderBy(o => o.DateCommande).ToList();
                    break;
            }

            RemplirCommandeListes(sortedList);
        }

        private void cbxLivres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLivres.SelectedIndex >= 0)
            {
                AfficheDetailsCommande();
                

            }

        }


        /// <summary>
        /// Affichage des informations du livre sélectionné
        /// </summary>
        /// <param name="livre">le livre</param>
        private void AfficheDetailsLivre(Livre livre)
        {
            txtauteur.Text = livre.Auteur;
            txtcollection.Text = livre.Collection;
            txtgenre.Text = livre.Genre;
            txtpublic.Text = livre.Public;
            txtrayon.Text = livre.Rayon;
            txttitre.Text = livre.Titre;
            AfficheDetailsCommande();

        }

        private void AfficheDetailsCommande()
        {
            Livre livre = (Livre)cbxLivres.SelectedItem;
            string idLivreDvd = livre.Id;
            lesDetailCommandes = frmgestionController.GetDetailCommande(idLivreDvd);
            RemplirCommandeListes(lesDetailCommandes);
            AccesDetailCommandeGroupBox(true);


        }

        private void AccesDetailCommandeGroupBox(bool acces)
        {
            gbdetails.Enabled = acces;
            txtcommande.Text = "";
            txtmontant.Text = "";
            txtnbexemplaire.Text = "";
            dtpcmd.Value = DateTime.Now;
        }

        private void btnrechercher_Click(object sender, EventArgs e)
        {

            if (cbxLivres.SelectedItem is Livre livre)
            {
                string idLivreDvd = livre.Id;  // Utilisez l'ID du livre
                lesDetailCommandes = frmgestionController.GetDetailCommande(idLivreDvd);

                AfficheDetailsLivre(livre);


            }
        }

        private void btnajout_Click(object sender, EventArgs e)
        {
            if (!txtcommande.Text.Equals("") && !txtmontant.Text.Equals("") && !txtnbexemplaire.Text.Equals(""))
            {
                try
                {
                    string idCommande = txtcommande.Text;
                    int idCommandeDocument = int.Parse(txtcommande.Text);
                    string idLivreDvd = cbxLivres.SelectedValue.ToString();
                    DateTime dateCommande = dtpcmd.Value;
                    decimal montant = decimal.Parse(txtmontant.Text);
                    int nbExemplaire = int.Parse(txtnbexemplaire.Text);
                    string etape = "En cours";

                    DetailsCommande detailsCommande = new DetailsCommande(idCommande, idCommandeDocument, dateCommande, montant, nbExemplaire, idLivreDvd, etape);

                    if (frmgestionController.CreerDetailCommande(detailsCommande))
                    {

                        AfficheDetailsCommande();
                        
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout dans la base de données.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Le montant et le nombre d'exemplaires doivent être numériques.", "Information");
                    txtmontant.Text = "";
                    txtnbexemplaire.Text = "";
                    txtmontant.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur");
                }
            }
            else
            {
                MessageBox.Show("Tous les champs obligatoires doivent être remplis.", "Information");
            }
        }
    }
}


