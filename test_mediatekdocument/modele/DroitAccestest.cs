using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class DroitAccestest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Complet", DroitAcces.Complet, "Devrait réussir : Complet retourné");
            Assert.AreEqual("Consultation", DroitAcces.Consultation, "Devrait réussir : Consultation retourné");
            Assert.AreEqual("Aucun", DroitAcces.Aucun, "Devrait réussir : Aucun retourné");
        }
    }
}
