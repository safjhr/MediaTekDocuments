using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class DetailAbonnementtest
    {
        private const string idCommande = "26";
        private const string idRevue = "10002";
        private const string idAbonnement = "26";
        private static readonly DateTime dateCommande = new DateTime(2024, 11, 28);
        private const decimal montant = 55;
        private static readonly DateTime dateFinAbonnement = new DateTime(2024, 11, 29);

        private readonly DetailsAbonnement detailsAbonnement = new DetailsAbonnement(idCommande, idRevue, idAbonnement, dateCommande, montant, dateFinAbonnement);

        [TestMethod()]
        public void DetailsAbonnementTests()
        {
            Assert.AreEqual(idCommande, detailsAbonnement.IdCommande, "Devrait réussir : IdCommande retourné");
            Assert.AreEqual(idRevue, detailsAbonnement.IdRevue, "Devrait réussir : IdRevue retourné");
            Assert.AreEqual(idAbonnement, detailsAbonnement.IdAbonnement, "Devrait réussir : IdAbonnement retourné");
            Assert.AreEqual(dateCommande, detailsAbonnement.DateCommande, "Devrait réussir : DateCommande retourné");
            Assert.AreEqual(montant, detailsAbonnement.Montant, "Devrait réussir : Montant retourné");
            Assert.AreEqual(dateFinAbonnement, detailsAbonnement.DateFinAbonnement, "Devrait réussir : DateFinAbonnement retourné");
        }

       
    }
}
