using System;
using TechTalk.SpecFlow;
using MediaTekDocuments.view;
using System.Windows.Forms;


namespace SpecFlowMediatekdocuments.Steps
{
    [Binding]
    public class RechercheDansLOngletLivresSteps
    {
        private Utilisateur utilisateur;
        private readonly FrmMediatek frmMediatek;
        public RechercheDansLOngletLivresSteps()
        {
            utilisateur = new Utilisateur(); 
            frmMediatek = new FrmMediatek(utilisateur);
        }
        [Given(@"la liste des livres est chargée")]
        public void GivenLaListeDesLivresEstChargee()
        {
            livresAffiches = ChargerTousLesLivres();
        }
        
        [When(@"je saisis ""(.*)"" dans le champ de recherche par numéro")]
        public void WhenJeSaisisDansLeChampDeRechercheParNumero(int p0)
        {
            livresAffiches = RechercherParNumero(numero);
        }
        
        [When(@"je saisis ""(.*)"" dans le champ de recherche par titre")]
        public void WhenJeSaisisDansLeChampDeRechercheParTitre(string p0)
        {
            livresAffiches = RechercherParTitre(titre);
        }
        
        [When(@"je sélectionne ""(.*)"" dans la liste des genres")]
        public void WhenJeSelectionneDansLaListeDesGenres(string p0)
        {
            livresAffiches = RechercherParGenre(genre);
        }
        
        [When(@"je sélectionne ""(.*)"" dans la liste des public")]
        public void WhenJeSelectionneDansLaListeDesPublic(string p0)
        {
            livresAffiches = RechercherParPublic(lePublic);
        }
        
        [When(@"je sélectionne ""(.*)"" dans la liste des rayons")]
        public void WhenJeSelectionneDansLaListeDesRayons(string p0)
        {
            livresAffiches = RechercherParRayon(rayon);
        }
        
        [Then(@"seul le livre avec le numéro ""(.*)"" est affiché")]
        public void ThenSeulLeLivreAvecLeNumeroEstAffiche(string numero)
        {
            Assert.AreEqual(1, livresAffiches.Count, "Un seul livre devrait être affiché.");
            Assert.AreEqual(numero, livresAffiches.First().Id, "Le numéro du livre affiché devrait correspondre.");
        }
        
        [Then(@"tous les livres contenant ""(.*)"" dans le titre sont affichés")]
        public void ThenTousLesLivresContenantDansLeTitreSontAffiches(string titre)
        {
            Assert.IsTrue(livresAffiches.All(l => l.Titre.Contains(titre, StringComparison.OrdinalIgnoreCase)),
             "Tous les livres affichés devraient contenir le titre recherché.");
        }
        
        [Then(@"seuls les livres du genre ""(.*)"" sont affichés")]
        public void ThenSeulsLesLivresDuGenreSontAffiches(string genre)
        {
            Assert.IsTrue(livresAffiches.All(l => l.Genre == genre), "Tous les livres affichés devraient appartenir au genre spécifié.");
        }
        
        [Then(@"seuls les livres du public ""(.*)"" sont affichés")]
        public void ThenSeulsLesLivresDuPublicSontAffiches(string lePublic)
        {
            Assert.IsTrue(livresAffiches.All(l => l.Public == lePublic), "Tous les livres affichés devraient appartenir au public spécifié.");
        }
        
        [Then(@"seuls les livres du rayon ""(.*)"" sont affichés")]
        public void ThenSeulsLesLivresDuRayonSontAffiches(string rayon)
        {
            Assert.IsTrue(livresAffiches.All(l => l.Rayon == rayon), "Tous les livres affichés devraient appartenir au rayon spécifié.");
        }

        private List<Livre> ChargerTousLesLivres()
        {
            return new List<Livre>
        {
            new Livre("00001", "Quand sort la recluse", "Policier", "Adultes", "Policiers français étrangers"),
            
        };
        }

        private List<Livre> RechercherParNumero(string numero)
        {
            return ChargerTousLesLivres().FindAll(l => l.Id == numero);
        }

        private List<Livre> RechercherParTitre(string titre)
        {
            return ChargerTousLesLivres().FindAll(l => l.Titre.Contains(titre, StringComparison.OrdinalIgnoreCase));
        }

        private List<Livre> RechercherParGenre(string genre)
        {
            return ChargerTousLesLivres().FindAll(l => l.Genre == genre);
        }

        private List<Livre> RechercherParPublic(string lePublic)
        {
            return ChargerTousLesLivres().FindAll(l => l.Public == lePublic);
        }

        private List<Livre> RechercherParRayon(string rayon)
        {
            return ChargerTousLesLivres().FindAll(l => l.Rayon == rayon);
        }
    }
}
