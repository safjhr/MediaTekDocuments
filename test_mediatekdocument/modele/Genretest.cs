using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Genretest
    {
        private const string id = "10002";
        private const string libelle = "Science Fiction";

        private readonly Genre genre = new Genre(id, libelle);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, genre.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(libelle, genre.Libelle, "Devrait réussir : Libelle retourné");
        }
    }
}
