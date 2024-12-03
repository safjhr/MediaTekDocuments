using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class CommandeDocumnttest
    {
        private const int id = 1;
        private const int nbExemplaire = 54;
        private const int idLivreDvd = 200003;
     
        
        private readonly CommandeDocument commandeDocument = new CommandeDocument(id, nbExemplaire, idLivreDvd);

        [TestMethod()]
        public void CommandeDocumentTests()
        {
            // Test des propriétés
            Assert.AreEqual(id, commandeDocument.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(nbExemplaire, commandeDocument.NbExemplaire, "Devrait réussir : NbExemplaire retourné");
            Assert.AreEqual(idLivreDvd, commandeDocument.IdLivreDvd, "Devrait réussir : IdLivreDvd retourné");
            
        }
    }
}
