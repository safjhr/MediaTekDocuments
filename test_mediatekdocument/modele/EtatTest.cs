using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class EtatTest
    {
        private const string id = "00001";
        private const string libelle = "neuf";

        private readonly Etat etat = new Etat(id, libelle);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, etat.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(libelle, etat.Libelle, "Devrait réussir : Libelle retourné");
        }
    }
}
