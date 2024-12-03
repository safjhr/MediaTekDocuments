using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;
namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Suivitest
    {
        private const int id = 88;
        private const int idCommandeDocument = 9;
        private const string etape = "En cours";

        private readonly Suivi suivi = new Suivi(id, idCommandeDocument, etape);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, suivi.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(idCommandeDocument, suivi.IdCommandeDocument, "Devrait réussir : IdCommandeDocument retourné");
            Assert.AreEqual(etape, suivi.Etape, "Devrait réussir : Etape retournée");
        }
    }
}
