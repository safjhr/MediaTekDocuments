using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class DetailsCommande
    {
        public string IdCommande { get; }
        public int IdCommandeDocument { get; }
        public DateTime DateCommande { get; }
        public decimal Montant { get; }
        public int NbExemplaire { get;  }
        public string IdLivreDvd { get; }
        public string Etape { get; set; }


        public DetailsCommande(string idCommande, int idCommandeDocument, DateTime dateCommande, decimal montant, int nbExemplaire, string idLivreDvd, string etape)
        {
            this.IdCommande = idCommande;
            this.IdCommandeDocument = idCommandeDocument;
            this.Etape = etape;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
        }
    }


}
