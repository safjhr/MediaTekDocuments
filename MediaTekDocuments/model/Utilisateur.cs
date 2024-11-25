using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Utilisateur
    {
       
        public string Pseudo { get; }
        public string Password { get; }
        

        public Utilisateur( string pseudo, string password)
         
        {
       
            this.Pseudo = pseudo;
            this.Password = password;
        
        }

    }
}
