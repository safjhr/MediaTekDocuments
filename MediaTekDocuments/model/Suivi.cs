using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Suivi
    {
        public int Id { get; }
        public int IdCommandeDocument { get; }
        public string Etape { get; }

        public Suivi(int id, int idCommande, string etape)
        {
            this.Id = id;
            this.IdCommandeDocument = idCommande;
            this.Etape = etape;
        }
    }
}
