﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Service
    {
        public string Pseudo { get;  }
        public string Password { get; }
        public int IdService { get; set; }
        public string NomService { get; set; }
        public string DroitsAcces { get; set; }

        public Service(string pseudo,string password, int idService, string nomService, string droitsAcces)
        {
            this.Pseudo = pseudo;
            this.Password = password;
            this.IdService = idService;
            this.NomService = nomService;
            this.DroitsAcces = droitsAcces;
        }
    }
}
