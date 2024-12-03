using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Publictest
    {
        private const string id = "00002";
        private const string libelle = "Adultes";

        private readonly Public publicEntity = new Public(id, libelle);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, publicEntity.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(libelle, publicEntity.Libelle, "Devrait réussir : Libelle retourné");
        }
    }
}
