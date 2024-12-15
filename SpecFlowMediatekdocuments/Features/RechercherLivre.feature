Feature: Recherche dans l'onglet Livres
  Afin de trouver rapidement un livre
  En tant qu'utilisateur
  Je veux pouvoir rechercher un livre par différents critères.

Scenario: Chercher un livre avec son numero dans txbLivresNumRecherche
	Given Je saisis la valeur 00001 dans txbLivresNumRecherche
	When Je clic sur le bouton Rechercher
	Then Les informations détaillées affichent le titre 'Quand sort la recluse'

Scenario: Chercher une liste de livres avec le genre dans cbxLivresGenres
	Given Je sélectionne la valeur 'Humour' dans cbxLivresGenres
	Then Le résultat est 6 livres dans dgvLivresListe

Scenario: Chercher une liste de livres avec le public dans cbxLivresPublics
	Given Je sélectionne la valeur 'Jeunesse' dans cbxLivresPublics
	Then Le résultat est 1 livres dans dgvLivresListe

Scenario: Chercher une liste de livres avec le rayon dans cbxLivresRayons
	Given Je sélectionne la valeur 'Bd Adultes' dans cbxLivresRayons
	Then Le résultat est 4 livre

Scenario: Chercher un livre avec son titre dans txbLivresTitreRecherche
	Given Je saisis la valeur 'Quand sort la recluse' dans txbLivresTitreRecherche
	When Je clic sur le bouton Rechercher
	Then Les informations détaillées affichent le titre 'Et je danse'

  