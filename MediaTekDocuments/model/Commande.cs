using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Commande
    {
        public String Id { get; }
        public DateTime DateCommande { get;}
        public decimal Montant { get; }

        public Commande(String id, DateTime dateCommande, decimal montant)
        {
            Id = id;
            DateCommande = dateCommande ;
            Montant = montant ;
        }
    }
}
