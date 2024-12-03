using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;
namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Servicetest
    {
        private const string pseudo = "user1";
        private const string password = "password123";
        private const int idService = 1;
        private const string nomService = "Administratif";
        private const string droitAcces = "Complet";

        private readonly Service service = new Service(pseudo, password, idService, nomService, droitAcces);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(pseudo, service.Pseudo, "Devrait réussir : Pseudo retourné");
            Assert.AreEqual(password, service.Password, "Devrait réussir : Password retourné");
            Assert.AreEqual(idService, service.IdService, "Devrait réussir : IdService retourné");
            Assert.AreEqual(nomService, service.NomService, "Devrait réussir : NomService retourné");
            Assert.AreEqual(droitAcces, service.DroitAcces, "Devrait réussir : DroitAcces retourné");
        }
    }
}
