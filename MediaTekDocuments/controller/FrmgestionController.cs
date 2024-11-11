using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

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

        
    }
}
