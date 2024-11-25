using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.controller
{
    class FrmgestionController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly FrmgestionAccess frmgestionaccess;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmgestionController()
        {
            frmgestionaccess = FrmgestionAccess.GetInstance();
        }

        /// <summary>
        /// getter sur la liste de commande
        /// </summary>
        /// <returns>liste d'objets Commande</returns>
        public List<Commande> GetAllCommandes()
        {
            return frmgestionaccess.GetAllCommandes();
        }

        /// <summary>
        /// getter sur la liste de commandedocuemnt
        /// </summary>
        /// <returns>liste d'objets commandeDocument</returns>
        public List<CommandeDocument> GetAllCommandedocuments()
        {
            return frmgestionaccess.GetAllCommandedocuments();
        }

        /// <summary>
        /// getter sur la liste de suivi
        /// </summary>
        /// <returns>liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivi()
        {
            return frmgestionaccess.GetAllSuivi();
        }


        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return frmgestionaccess.GetAllLivres();
        }

        public List<DetailsCommande> GetDetailCommande(string idLivreDvd)
        {
            return frmgestionaccess.GetDetailCommande(idLivreDvd);

        }

        /// <summary>
        /// Crée un détail de commande dans la base de données
        /// </summary>
        /// <param name="detailsCommande">L'objet DetailsCommande à insérer</param>
        /// <returns>Création du details</returns>
        public bool CreerDetailCommande(DetailsCommande detailsCommande)
        {
            return frmgestionaccess.CreerDetailCommande(detailsCommande);
        }


        public bool ModifierDetailCommande(DetailsCommande detailsCommande)
        {
            return frmgestionaccess.ModifierDetailCommande(detailsCommande);
        }

        public bool SupprimerDetailCommande(DetailsCommande detailsCommande)
        {
            return frmgestionaccess.SupprimerDetailCommande(detailsCommande);
        }

        public List<DetailsAbonnement> GetDetailAbonnement(string idRevue)
        {
            return frmgestionaccess.GetDetailAbonnement(idRevue);

        }

        public bool CreerDetailAbonnement(DetailsAbonnement detailsAbonnement)
        {
            return frmgestionaccess.CreerDetailAbonnement(detailsAbonnement);
        }

        public bool SupprimerDetailAbonnement(DetailsAbonnement detailsAbonnement)
        {
            return frmgestionaccess.SupprimerDetailAbonnement(detailsAbonnement);
        }

        public List<DetailsAbonnement> ObtenirRevuesALerter(string idRevue)
        {
            List<DetailsAbonnement> toutesLesAbonnements = FrmgestionAccess.GetInstance().GetDetailAbonnement(idRevue);
            DateTime dateLimite = DateTime.Now.AddDays(30).Date;
            List<DetailsAbonnement> AbonnementALerter = toutesLesAbonnements
                .Where(r => r.DateFinAbonnement.HasValue && r.DateFinAbonnement.Value.Date <= dateLimite)  
                .OrderBy(r => r.DateFinAbonnement.Value)
                .ToList();
            return AbonnementALerter;
        }

        public bool GetAllUtilisateur(Utilisateur utilisateur)
        {
            return frmgestionaccess.GetAllUtilisateur(utilisateur);
        }

        public List<Service> GetService(string pseudo)
        {
            return frmgestionaccess.GetService(pseudo);
        }
    }
}
