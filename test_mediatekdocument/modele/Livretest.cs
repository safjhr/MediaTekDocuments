using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Livretest
    {
        private const string id = "00001";
        private const string titre = "Quand sort la recluse";
        private const string image = null;
        private const string isbn = "1234569877896";
        private const string auteur = "Fred Vargas";
        private const string collection = "Commissaire Adamsberg";
        private const string idGenre = "10014";
        private const string genre = "Policier";
        private const string idPublic = "00002";
        private const string publicDoc = "Adultes";
        private const string idRayon = "LV003";
        private const string rayon = "Policiers français étrangers";

        private readonly Livre livre = new Livre(id, titre, image, isbn, auteur, collection, idGenre, genre, idPublic, publicDoc, idRayon, rayon);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, livre.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(titre, livre.Titre, "Devrait réussir : Titre retourné");
            Assert.AreEqual(image, livre.Image, "Devrait réussir : Image retourné");
            Assert.AreEqual(isbn, livre.Isbn, "Devrait réussir : ISBN retourné");
            Assert.AreEqual(auteur, livre.Auteur, "Devrait réussir : Auteur retourné");
            Assert.AreEqual(collection, livre.Collection, "Devrait réussir : Collection retournée");
            Assert.AreEqual(idGenre, livre.IdGenre, "Devrait réussir : IdGenre retourné");
            Assert.AreEqual(genre, livre.Genre, "Devrait réussir : Genre retourné");
            Assert.AreEqual(idPublic, livre.IdPublic, "Devrait réussir : IdPublic retourné");
            Assert.AreEqual(publicDoc, livre.Public, "Devrait réussir : Public retourné");
            Assert.AreEqual(idRayon, livre.IdRayon, "Devrait réussir : IdRayon retourné");
            Assert.AreEqual(rayon, livre.Rayon, "Devrait réussir : Rayon retourné");
        }

    }
}
