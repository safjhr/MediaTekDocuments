using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class DetailsAbonnement
    {
        public string IdCommande { get; }
        public string IdRevue { get; }
        public string IdAbonnement { get; }
        public DateTime DateCommande { get; }
        public decimal Montant { get; }
        public DateTime? DateFinAbonnement { get; set;  }

        public DetailsAbonnement(string idCommande, string idRevue, string idAbonnement, DateTime dateCommande, decimal montant, DateTime dateFinAbonnement)
        {
            this.IdCommande = idCommande;
            this.IdRevue = idRevue;
            this.IdAbonnement = idAbonnement;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.DateFinAbonnement = dateFinAbonnement;
        }

        public static bool ParutionDansAbonnement(DateTime dateCommande, DateTime dateFinAbonnement, DateTime dateAchat)
        {
            return dateAchat >= dateCommande && dateAchat <= dateFinAbonnement;
        }
    }
}
