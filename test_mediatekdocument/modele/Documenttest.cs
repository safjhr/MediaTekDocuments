using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Documenttest
    {
        private const string id = "00001";
        private const string titre = "Quand sort la recluse";
        private const string image = null;
        private const string idGenre = "10014";
        private const string genre = "Policier";
        private const string idPublic = "00002";
        private const string lePublic = "Adultes";
        private const string idRayon = "LV003";
        private const string rayon = "Policiers français étrangers";

        private readonly Document document = new Document(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, document.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(titre, document.Titre, "Devrait réussir : Titre retourné");
            Assert.AreEqual(image, document.Image, "Devrait réussir : Image retourné");
            Assert.AreEqual(idGenre, document.IdGenre, "Devrait réussir : IdGenre retourné");
            Assert.AreEqual(genre, document.Genre, "Devrait réussir : Genre retourné");
            Assert.AreEqual(idPublic, document.IdPublic, "Devrait réussir : IdPublic retourné");
            Assert.AreEqual(lePublic, document.Public, "Devrait réussir : Public retourné");
            Assert.AreEqual(idRayon, document.IdRayon, "Devrait réussir : IdRayon retourné");
            Assert.AreEqual(rayon, document.Rayon, "Devrait réuPolicierssir : Rayon retourné");
        }
    }
}
