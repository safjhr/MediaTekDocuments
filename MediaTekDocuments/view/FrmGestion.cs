using System;
using System.Windows.Forms;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using MediaTekDocuments.controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace MediaTekDocuments.view
{
    public partial class FrmGestion : Form
    {
        private readonly BindingSource bdgLivres = new BindingSource();
        private readonly BindingSource bdgDetailCommande = new BindingSource();
        private List<Livre> lesLivres;
        private List<DetailsCommande> lesDetailCommandes = new List<DetailsCommande>();
        
        private readonly FrmgestionController frmgestionController;
        private readonly FrmMediatekController controller;

        public FrmGestion()
        {
            InitializeComponent();
            frmgestionController = new FrmgestionController();
            this.controller = new FrmMediatekController();
            ChargerLivresListeComplete();
            ChargerLivres();
            cbxLivres.SelectedIndex = -1;
            dgvCommandesListe.AutoGenerateColumns = false;
        }

        #region Onglet Livre


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
                string idLivreDvd = livre.Id; 
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
                        dgvCommandesListe.ClearSelection();

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

        private void dgvCommandesListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               
                var detailscommande = (DetailsCommande)dgvCommandesListe.Rows[e.RowIndex].DataBoundItem;
                txtcommande.Text = detailscommande.IdCommande.ToString();
                dtpcmd.Value = detailscommande.DateCommande;
                txtmontant.Text = detailscommande.Montant.ToString();
                txtnbexemplaire.Text = detailscommande.NbExemplaire.ToString();


                cmbEtapeSuivi.Items.Clear();
                cmbEtapeSuivi.Items.AddRange(new string[] { "En cours", "Relancée", "Livrée", "Réglée" });
                cmbEtapeSuivi.SelectedItem = detailscommande.Etape;
            }
        }

        private void btnmodif_Click(object sender, EventArgs e)
        {
            if (!txtcommande.Text.Equals("") && cmbEtapeSuivi.SelectedItem != null)
            {
                try
                {
                    string idLivreDvd = cbxLivres.SelectedValue?.ToString(); 
                    string nouvelleEtape = cmbEtapeSuivi.SelectedItem.ToString();

                    Console.WriteLine("ID du livre/DVD: " + idLivreDvd);

                    var detailsCommande = frmgestionController.GetDetailCommande(idLivreDvd).FirstOrDefault();

                    if (detailsCommande == null)
                    {
                        MessageBox.Show($"Commande pour le livre/DVD avec l'ID {idLivreDvd} non trouvée.", "Erreur");
                        return;
                    }

                    if (detailsCommande.Etape == "Livrée" || detailsCommande.Etape == "Réglée")
                    {
                        if (nouvelleEtape == "En cours" || nouvelleEtape == "Relancée")
                        {
                            MessageBox.Show("Une commande livrée ou réglée ne peut pas revenir à une étape précédente.");
                            return;
                        }
                    }

                    if (nouvelleEtape == "Réglée" && detailsCommande.Etape != "Livrée")
                    {
                        MessageBox.Show("Une commande ne peut être réglée que si elle est livrée.");
                        return;
                    }

                    detailsCommande.Etape = nouvelleEtape;  

                    if (frmgestionController.ModifierDetailCommande(detailsCommande))
                    {
                        MessageBox.Show("L'étape de suivi de la commande a été mise à jour avec succès.");
                        AfficheDetailsCommande();
                        dgvCommandesListe.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la mise à jour de l'étape de suivi.");
                    }
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

        private void btnsupp_Click(object sender, EventArgs e)
        {

            if (dgvCommandesListe.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCommandesListe.SelectedRows[0];
                var detailsCommande = selectedRow.DataBoundItem as DetailsCommande;

                if (detailsCommande != null)
                {
                    Console.WriteLine("IdCommande dans la ligne sélectionnée : " + detailsCommande.IdCommande);
                    if (frmgestionController.SupprimerDetailCommande(detailsCommande))
                    {
                        MessageBox.Show("La ligne a été supprimée avec succès.");
                        AfficheDetailsCommande();
                        dgvCommandesListe.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de la ligne.");
                    }
                }
                else
                {
                    MessageBox.Show("Détails de la commande non valides.");
                }
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée.");
            }
        }
        #endregion

        #region Onglet Dvd
        private List<Dvd> lesDvds;
        private readonly BindingSource bdgDvd = new BindingSource();
        private void tabdvd_Enter(object sender, EventArgs e)
        {
            ChargerDvdListeComplete();
            ChargerDvd();
            cbxDvd.SelectedIndex = -1;
            dgvdvd.AutoGenerateColumns = false;
        }

        private void ChargerDvdListeComplete()
        {
            lesDvds = Access.GetInstance().GetAllDvd();
        }

        private void ChargerDvd()
        {
            List<Dvd> dvds = lesDvds;
            bdgDvd.DataSource = dvds;
            cbxDvd.DataSource = bdgDvd;
            cbxDvd.DisplayMember = "Id";
            cbxDvd.ValueMember = "Id";
        }

        private void AfficherDetailDvd ( Dvd dvd )
        {
            txtTitredvd.Text = dvd.Titre;
            txtduree.Text = dvd.Duree.ToString();
            txtrealisateur.Text = dvd.Realisateur;
            txtgenreDvd.Text = dvd.Genre;
            txtpublicdvd.Text = dvd.Public;
            txtrayondvd.Text = dvd.Rayon;
            AfficheDetailsDvdListe();


        }

        private void AfficheDetailsDvdListe()
        {
            Dvd dvd = (Dvd)cbxDvd.SelectedItem;
            string idLivreDvd = dvd.Id;
            lesDetailCommandes = frmgestionController.GetDetailCommande(idLivreDvd);
            RemplirDvdListe(lesDetailCommandes);
            AccesDetailDvdGroupBox(true);


        }
        private void RemplirDvdListe(List<DetailsCommande> lesDetailCommandes)

        {
            if (lesDetailCommandes != null)
            {
                bdgDetailCommande.DataSource = lesDetailCommandes;
                dgvdvd.DataSource = bdgDetailCommande;
                dgvdvd.Columns["dateCommande"].DisplayIndex = 0;
                dgvdvd.Columns["montant"].DisplayIndex = 1;
                dgvdvd.Columns["nbExemplaire"].DisplayIndex = 2;
                dgvdvd.Columns["etape"].DisplayIndex = 3;
                dgvdvd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvdvd.Columns["idCommande"].Visible = false;
                dgvdvd.Columns["idCommandeDocument"].Visible = false;
                dgvdvd.Columns["idLivreDvd"].Visible = false;


            }
            else
            {
                bdgDetailCommande.DataSource = null;
            }
        }

        private void AccesDetailDvdGroupBox(bool acces)
        {
            gbddetaildvd.Enabled = acces;
            txtcmddvd.Text = string.Empty;
            txtmtdvd.Text = string.Empty;
            txtnbdvd.Text = string.Empty;
            dtpdvd.Value = DateTime.Now;
        }

        private void dgvdvd_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvdvd.Columns[e.ColumnIndex].HeaderText;
            List<DetailsCommande> sortedList = new List<DetailsCommande>();

            switch (titreColonne)
            {
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

            RemplirDvdListe(sortedList);

        }

        private void btnrechercher2_Click(object sender, EventArgs e)
        {
            if (cbxDvd.SelectedItem is Dvd dvd)
            {
                string idLivreDvd = dvd.Id;
                lesDetailCommandes = frmgestionController.GetDetailCommande(idLivreDvd);

                AfficherDetailDvd(dvd);
                dgvdvd.ClearSelection();


            }

        }
        
        

        private void btnajoutdvd_Click(object sender, EventArgs e)
        {
            if (!txtcmddvd.Text.Equals("") && !txtmtdvd.Text.Equals("") && !txtnbdvd.Text.Equals(""))
            {
                try
                {
                    string idCommande = txtcmddvd.Text;
                    int idCommandeDocument = int.Parse(txtcmddvd.Text);
                    string idLivreDvd = cbxDvd.SelectedValue.ToString();
                    DateTime dateCommande = dtpdvd.Value;
                    decimal montant = decimal.Parse(txtmtdvd.Text);
                    int nbExemplaire = int.Parse(txtnbdvd.Text);
                    string etape = "En cours";

                    DetailsCommande detailsCommande = new DetailsCommande(idCommande, idCommandeDocument, dateCommande, montant, nbExemplaire, idLivreDvd, etape);

                    if (frmgestionController.CreerDetailCommande(detailsCommande))
                    {

                        AfficheDetailsDvdListe();
                        dgvdvd.ClearSelection();

                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout dans la base de données.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Le montant et le nombre d'exemplaires doivent être numériques.", "Information");
                    txtmtdvd.Text = "";
                    txtnbdvd.Text = "";
                    txtcmddvd.Focus();
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

        private void dgvdvd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var detailscommande = (DetailsCommande)dgvdvd.Rows[e.RowIndex].DataBoundItem;
                txtcmddvd.Text = detailscommande.IdCommande.ToString();
                dtpdvd.Value = detailscommande.DateCommande;
                txtmtdvd.Text = detailscommande.Montant.ToString();
                txtnbdvd.Text = detailscommande.NbExemplaire.ToString();


                cmbsuividvd.Items.Clear();
                cmbsuividvd.Items.AddRange(new string[] { "En cours", "Relancée", "Livrée", "Réglée" });
                cmbsuividvd.SelectedItem = detailscommande.Etape;
            }
        }

        private void btnmodifdvd_Click(object sender, EventArgs e)
        {
            if (!txtcmddvd.Text.Equals("") && cmbsuividvd.SelectedItem != null)
            {
                try
                {
                    string idLivreDvd = cbxDvd.SelectedValue?.ToString();
                    string nouvelleEtape = cmbsuividvd.SelectedItem.ToString();

                    Console.WriteLine("ID du DVD: " + idLivreDvd);

                    var detailsCommande = frmgestionController.GetDetailCommande(idLivreDvd).FirstOrDefault();

                    if (detailsCommande == null)
                    {
                        MessageBox.Show($"Commande pour le livre/DVD avec l'ID {idLivreDvd} non trouvée.", "Erreur");
                        return;
                    }

                    if (detailsCommande.Etape == "Livrée" || detailsCommande.Etape == "Réglée")
                    {
                        if (nouvelleEtape == "En cours" || nouvelleEtape == "Relancée")
                        {
                            MessageBox.Show("Une commande livrée ou réglée ne peut pas revenir à une étape précédente.");
                            return;
                        }
                    }

                    if (nouvelleEtape == "Réglée" && detailsCommande.Etape != "Livrée")
                    {
                        MessageBox.Show("Une commande ne peut être réglée que si elle est livrée.");
                        return;
                    }

                    detailsCommande.Etape = nouvelleEtape;

                    if (frmgestionController.ModifierDetailCommande(detailsCommande))
                    {
                        MessageBox.Show("L'étape de suivi de la commande a été mise à jour avec succès.");
                        AfficheDetailsDvdListe();
                        dgvdvd.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la mise à jour de l'étape de suivi.");
                    }
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

     

        private void cbxDvd_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxDvd.SelectedIndex >= 0)
            {
                AfficheDetailsDvdListe();
            }
        }


        private void btnsuppdvd_Click(object sender, EventArgs e)
        {

            if (dgvdvd.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvdvd.SelectedRows[0];
                var detailsCommande = selectedRow.DataBoundItem as DetailsCommande;

                if (detailsCommande != null)
                {
                    Console.WriteLine("IdCommande dans la ligne sélectionnée : " + detailsCommande.IdCommande);
                    if (frmgestionController.SupprimerDetailCommande(detailsCommande))
                    {
                        MessageBox.Show("La ligne a été supprimée avec succès.");
                        AfficheDetailsDvdListe();
                        dgvCommandesListe.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de la ligne.");
                    }
                }
                else
                {
                    MessageBox.Show("Détails de la commande non valides.");
                }
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée.");
            }
        }

        #endregion

        #region Onglet Revue
       
        private List<Revue> lesRevues;
        private List<DetailsAbonnement> lesDetailAbonnements = new List<DetailsAbonnement>();
        private readonly BindingSource bdgRevue = new BindingSource();
        private readonly BindingSource bdgDetailAbonnement = new BindingSource();

        private void tabRevue_Enter(object sender, EventArgs e)
        {
            ChargerRevueListeComplete();
            ChargerRevue();
            cbxrevue.SelectedIndex = -1;
        }
        private void ChargerRevueListeComplete()
        {
            lesRevues = Access.GetInstance().GetAllRevues();
        }

        private void ChargerRevue()
        {
            List<Revue> revues = lesRevues;
            bdgRevue.DataSource = revues;
            cbxrevue.DataSource = bdgRevue;
            cbxrevue.DisplayMember = "Id";
            cbxrevue.ValueMember = "Id";
        }

        private void AfficherDetailRevue(Revue revue)
        {
            txtTitrerevue.Text = revue.Titre;
            txtperiodrevue.Text = revue.Periodicite.ToString();
            txtdmd.Text = revue.DelaiMiseADispo.ToString();
            txtgenrerevue.Text = revue.Genre;
            txtpublicrevue.Text = revue.Public;
            txtrayonrevue.Text = revue.Rayon;
            AfficheDetailsRevueListe();

        }

        private void AfficheDetailsRevueListe()
        {
            Revue revue = (Revue)cbxrevue.SelectedItem;
            string idRevue = revue.Id;
            lesDetailAbonnements = frmgestionController.GetDetailAbonnement(idRevue);
            RemplirRevue(lesDetailAbonnements);
           


        }

        private void RemplirRevue(List<DetailsAbonnement> lesDetailAbonnements)

        {
            if (lesDetailAbonnements != null)
            {
                bdgDetailAbonnement.DataSource = lesDetailAbonnements;
                dgvRevue.DataSource = bdgDetailAbonnement;
                dgvRevue.Columns["dateCommande"].DisplayIndex = 0;
                dgvRevue.Columns["montant"].DisplayIndex = 1;
                dgvRevue.Columns["dateFinAbonnement"].DisplayIndex = 2;
                dgvRevue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvRevue.Columns["idCommande"].Visible = false;
                dgvRevue.Columns["idAbonnement"].Visible = false;
                dgvRevue.Columns["idRevue"].Visible = false;


            }
            else
            {
                bdgDetailAbonnement.DataSource = null;
            }
        }


        private void dgvRevue_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvRevue.Columns[e.ColumnIndex].HeaderText;
            List<DetailsAbonnement> sortedList = new List<DetailsAbonnement>();

            switch (titreColonne)
            {
                case "dateCommande":
                    sortedList = lesDetailAbonnements.OrderBy(o => o.DateCommande).ToList();
                    break;
                case "montant":
                    sortedList = lesDetailAbonnements.OrderBy(o => o.Montant).ToList();
                    break;
                case "dateFinAbonnement":
                    sortedList = lesDetailAbonnements.OrderBy(o => o.DateFinAbonnement).ToList();
                    break;
            }

            RemplirRevue(sortedList);
        }

        private void btnrechercherrevue_Click(object sender, EventArgs e)
        {

            if (cbxrevue.SelectedItem is Revue revue)
            {
                string idRevue = revue.Id; 
                List<DetailsAbonnement> AbonnementALerter = frmgestionController.ObtenirRevuesALerter(idRevue);

                if (AbonnementALerter != null && AbonnementALerter.Count > 0)
                {
                    StringBuilder message = new StringBuilder("Les abonnements suivants se terminent dans moins de 30 jours :\n");

                    foreach (var detailsAbonnement in AbonnementALerter)
                    {
                        message.AppendLine($"{detailsAbonnement.IdRevue} - Fin le: {detailsAbonnement.DateFinAbonnement.Value.ToString("dd/MM/yyyy")}");
                    }

                    // Afficher l'alerte
                    MessageBox.Show(message.ToString(), "Alerte : Abonnement à venir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Aucune revue dont l'abonnement se termine dans moins de 30 jours.", "Alerte : Abonnement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                var lesDetailAbonnements = frmgestionController.GetDetailAbonnement(idRevue);

                AfficherDetailRevue(revue);
                dgvRevue.ClearSelection();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une revue avant de rechercher.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnajoutrevue_Click(object sender, EventArgs e)
        {

            if (!txtnumabo.Text.Equals("") && !txtmtrevue.Text.Equals(""))
            {
                try
                {
                    string idCommande = txtnumabo.Text;
                    string idAbonnement = txtnumabo.Text ;
                    string idRevue = cbxrevue.SelectedValue.ToString();
                    DateTime dateCommande = dtprevue.Value;
                    decimal montant = decimal.Parse(txtmtrevue.Text);
                    DateTime dateFinAbonnement = dtpfinrevue.Value;

                    DetailsAbonnement detailsAbonnement = new DetailsAbonnement(idCommande, idRevue, idAbonnement,  dateCommande, montant, dateFinAbonnement);

                    if (frmgestionController.CreerDetailAbonnement(detailsAbonnement))
                    {

                        AfficheDetailsRevueListe();
                        dgvRevue.ClearSelection();

                    }
                    else
                    {
                        MessageBox.Show("Échec de l'ajout dans la base de données.");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Le montant et le nombre d'exemplaires doivent être numériques.", "Information");
                    txtnumabo.Text = "";
                    txtmtrevue.Text = "";
                    
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

        

        private void cbxrevue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxrevue.SelectedIndex >= 0)
            {
                AfficheDetailsRevueListe();
            }
        }

        private void btnsupprevue_Click(object sender, EventArgs e)
        {
            if (dgvRevue.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRevue.SelectedRows[0];
                var detailsAbonnement = selectedRow.DataBoundItem as DetailsAbonnement;

                if (detailsAbonnement != null)
                {
                    var exemplaires = controller.GetExemplairesRevue(detailsAbonnement.IdAbonnement);
                    bool exemplaireRattache = exemplaires.Any(exemplaire =>
                        DetailsAbonnement.ParutionDansAbonnement(detailsAbonnement.DateCommande, detailsAbonnement.DateFinAbonnement.Value, exemplaire.DateAchat));

                    if (exemplaireRattache)
                    {
                        MessageBox.Show("Impossible de supprimer l'abonnement. Un ou plusieurs exemplaires sont rattachés.");
                        return;
                    }
                    if (frmgestionController.SupprimerDetailAbonnement(detailsAbonnement))
                    {
                        MessageBox.Show("L'abonnement a été supprimé avec succès.");

                        AfficheDetailsRevueListe();

                        dgvRevue.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'abonnement.");
                    }
                }
                else
                {
                    MessageBox.Show("Aucune ligne sélectionnée.");
                }
            }
        }
            #endregion
        }
    }


