using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MediaTekDocuments.model;

namespace test_mediatekdocument.modele
{
    /// <summary>
    /// Description résumée pour Utilisateurtest
    /// </summary>
    [TestClass]
    public class Utilisateurtest
    {
        private const string pseudo = "user";
        private const string password = "password123";

        private readonly Utilisateur utilisateur = new Utilisateur(pseudo, password);

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(pseudo, utilisateur.Pseudo, "Devrait réussir : Pseudo retourné");
            Assert.AreEqual(password, utilisateur.Password, "Devrait réussir : Password retourné");
        }
    }
}
