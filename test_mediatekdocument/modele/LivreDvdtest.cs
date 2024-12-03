using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class LivreDvdtest
    {
        private const string id = "00001";
        private const string titre = "Quand sort la recluse";
        private const string image = null;
        private const string idGenre = "10014";
        private const string genre = "Policier";
        private const string idPublic = "00002";
        private const string publicDoc = "Adultes";
        private const string idRayon = "LV003";
        private const string rayon = "Policiers français étrangers";

        private readonly LivreDvd livreDvd = new LivreDvdTestImplementation(id, titre, image, idGenre, genre, idPublic, publicDoc, idRayon, rayon);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, livreDvd.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(titre, livreDvd.Titre, "Devrait réussir : Titre retourné");
            Assert.AreEqual(image, livreDvd.Image, "Devrait réussir : Image retourné");
            Assert.AreEqual(idGenre, livreDvd.IdGenre, "Devrait réussir : IdGenre retourné");
            Assert.AreEqual(genre, livreDvd.Genre, "Devrait réussir : Genre retourné");
            Assert.AreEqual(idPublic, livreDvd.IdPublic, "Devrait réussir : IdPublic retourné");
            Assert.AreEqual(publicDoc, livreDvd.Public, "Devrait réussir : Public retourné");
            Assert.AreEqual(idRayon, livreDvd.IdRayon, "Devrait réussir : IdRayon retourné");
            Assert.AreEqual(rayon, livreDvd.Rayon, "Devrait réuPolicierssir : Rayon retourné");
        }

        private class LivreDvdTestImplementation : LivreDvd
        {
            public LivreDvdTestImplementation(string id, string titre, string image, string idGenre, string genre, string idPublic, string publicDoc, string idRayon, string rayon)
                : base(id, titre, image, idGenre, genre, idPublic, publicDoc, idRayon, rayon)
            {
            }
        

        }
    }
}
