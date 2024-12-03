using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class DetailCommandetest
    {
        private const string idCommande = "1";
        private const int idCommandeDocument = 1;
        private static readonly DateTime dateCommande = new DateTime(2024, 11, 15);
        private const decimal montant = 23;
        private const int nbExemplaire = 54;
        private const string idLivreDvd = "20003";
        private const string etape = "En Cours";

        // Instance à tester
        private readonly DetailsCommande detailsCommande = new DetailsCommande(idCommande, idCommandeDocument, dateCommande, montant, nbExemplaire, idLivreDvd, etape);

        [TestMethod()]
        public void DetailsCommandesTests()
        {
            Assert.AreEqual(idCommande, detailsCommande.IdCommande, "Devrait réussir : IdCommande retourné");
            Assert.AreEqual(idCommandeDocument, detailsCommande.IdCommandeDocument, "Devrait réussir : IdCommandeDocument retourné");
            Assert.AreEqual(dateCommande, detailsCommande.DateCommande, "Devrait réussir : DateCommande retourné");
            Assert.AreEqual(montant, detailsCommande.Montant, "Devrait réussir : Montant retourné");
            Assert.AreEqual(nbExemplaire, detailsCommande.NbExemplaire, "Devrait réussir : NbExemplaire retourné");
            Assert.AreEqual(idLivreDvd, detailsCommande.IdLivreDvd, "Devrait réussir : IdLivreDvd retourné");
            Assert.AreEqual(etape, detailsCommande.Etape, "Devrait réussir : Etape retourné");
        }
    }
}
