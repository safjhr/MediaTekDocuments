using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    [TestClass]
    public class DroitsAccestest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Complet", DroitsAcces.Complet, "Devrait réussir : Complet retourné");
            Assert.AreEqual("Consultation", DroitsAcces.Consultation, "Devrait réussir : Consultation retourné");
            Assert.AreEqual("Aucun", DroitsAcces.Aucun, "Devrait réussir : Aucun retourné");
        }
    }
}
