using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class CommandeTest
    {
        private const string id = "1";
        private static readonly DateTime dateCommande = new DateTime(2024, 11, 15);
        private const decimal montant = 23;

        // Instance à tester
        private readonly Commande commande = new Commande(id, dateCommande, montant);

        [TestMethod()]
        public void CommandeTests()
        {
            
            Assert.AreEqual(id, commande.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(dateCommande, commande.DateCommande, "Devrait réussir : DateCommande retournée");
            Assert.AreEqual(montant, commande.Montant, "Devrait réussir : Montant retourné");
        }
    }
}
