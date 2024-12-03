using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class CategoriesTest
    {
        private const string id = "BD001";
        private const string libelle = "BD Adultes";

        private readonly Categorie categorie = new Categorie(id, libelle);

        [TestMethod()]
        public void CategorieTests()
        {
            Assert.AreEqual(id, categorie.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(libelle, categorie.Libelle, "Devrait réussir : Libelle retourné");
        }

    }
}
