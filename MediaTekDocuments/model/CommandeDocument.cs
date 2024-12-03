using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class CommandeDocument
    {
        public int Id { get; } 
        public int NbExemplaire { get; }
        public int IdLivreDvd { get;  } 
        
        public CommandeDocument(int id, int nbExemplaire, int idLivreDvd)
        {
            this.Id = id;
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            
        }
    }
}
