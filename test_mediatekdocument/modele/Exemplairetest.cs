using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Exemplairetest
    {
        private const int numero = 417;
        private static readonly DateTime dateAchat = new DateTime(2024, 11, 08);
        private const string photo = null;
        private const string idEtat = "00004";
        private const string id = "10002";

        private readonly Exemplaire exemplaire = new Exemplaire(numero, dateAchat, photo, idEtat, id);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(numero, exemplaire.Numero, "Devrait réussir : Numero retourné");
            Assert.AreEqual(dateAchat, exemplaire.DateAchat, "Devrait réussir : DateAchat retourné");
            Assert.AreEqual(photo, exemplaire.Photo, "Devrait réussir : Photo retourné");
            Assert.AreEqual(idEtat, exemplaire.IdEtat, "Devrait réussir : IdEtat retourné");
            Assert.AreEqual(id, exemplaire.Id, "Devrait réussir : Id retourné");
        }
    }
}
