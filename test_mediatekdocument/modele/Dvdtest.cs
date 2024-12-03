using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Dvdtest
    {
        private const string id = "20001";
        private const string titre = "Star Wars 5 L'empire contre attaque";
        private const string image = null;
        private const int duree = 124;
        private const string realisateur = "George Lucas";
        private const string synopsis = "Luc est entraîné par Yoda pendant que Han et Leia tentent de se cacher dans la cité des nuages.";
        private const string idGenre = "10002";
        private const string genre = "Science Fiction";
        private const string idPublic = "00003";
        private const string publicDoc = "Tous publics";
        private const string idRayon = "DF001";
        private const string rayon = "DVD films";

        private readonly Dvd dvd = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, publicDoc, idRayon, rayon);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, dvd.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(titre, dvd.Titre, "Devrait réussir : Titre retourné");
            Assert.AreEqual(image, dvd.Image, "Devrait réussir : Image retourné");
            Assert.AreEqual(duree, dvd.Duree, "Devrait réussir : Durée retournée");
            Assert.AreEqual(realisateur, dvd.Realisateur, "Devrait réussir : Réalisateur retourné");
            Assert.AreEqual(synopsis, dvd.Synopsis, "Devrait réussir : Synopsis retourné");
            Assert.AreEqual(idGenre, dvd.IdGenre, "Devrait réussir : IdGenre retourné");
            Assert.AreEqual(genre, dvd.Genre, "Devrait réussir : Genre retourné");
            Assert.AreEqual(idPublic, dvd.IdPublic, "Devrait réussir : IdPublic retourné");
            Assert.AreEqual(publicDoc, dvd.Public, "Devrait réussir : Public retourné");
            Assert.AreEqual(idRayon, dvd.IdRayon, "Devrait réussir : IdRayon retourné");
            Assert.AreEqual(rayon, dvd.Rayon, "Devrait réussir : Rayon retourné");
        }
    }
}
