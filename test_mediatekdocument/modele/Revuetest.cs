using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class Revuetest
    {
        private const string id = "10001";
        private const string titre = "Arts Magazine";
        private const string image = null ;
        private const string idGenre = "10016";
        private const string genre = "Presse Economique";
        private const string idPublic = "00002";
        private const string lePublic = "Adultes";
        private const string idRayon = "PR002";
        private const string rayon = "Magazines";
        private const string periodicite = "MS";
        private const int delaiMiseADispo = 52;

        private readonly Revue revue = new Revue(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon, periodicite, delaiMiseADispo);

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(id, revue.Id, "Devrait réussir : Id retourné");
            Assert.AreEqual(titre, revue.Titre, "Devrait réussir : Titre retourné");
            Assert.AreEqual(image, revue.Image, "Devrait réussir : Image retourné");
            Assert.AreEqual(idGenre, revue.IdGenre, "Devrait réussir : IdGenre retourné");
            Assert.AreEqual(genre, revue.Genre, "Devrait réussir : Genre retourné");
            Assert.AreEqual(idPublic, revue.IdPublic, "Devrait réussir : IdPublic retourné");
            Assert.AreEqual(lePublic, revue.Public, "Devrait réussir : Public retourné");
            Assert.AreEqual(idRayon, revue.IdRayon, "Devrait réussir : IdRayon retourné");
            Assert.AreEqual(rayon, revue.Rayon, "Devrait réussir : Rayon retourné");
            Assert.AreEqual(periodicite, revue.Periodicite, "Devrait réussir : Periodicite retournée");
            Assert.AreEqual(delaiMiseADispo, revue.DelaiMiseADispo, "Devrait réussir : DelaiMiseADispo retourné");
        }
    }
}
