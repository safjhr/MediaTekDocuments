
Feature: Recherche dans l'onglet Livres
  Afin de trouver rapidement un livre
  En tant qu'utilisateur
  Je veux pouvoir rechercher un livre par différents critères.

  Scenario: Rechercher un livre par numéro
    Given la liste des livres est chargée
    When je saisis "00001" dans le champ de recherche par numéro
    Then seul le livre avec le numéro "00001" est affiché

  Scenario: Rechercher un livre par titre partiel
    Given la liste des livres est chargée
    When je saisis "Quand sort la recluse" dans le champ de recherche par titre
    Then tous les livres contenant "Quand sort la recluse" dans le titre sont affichés

  Scenario: Rechercher un livre par genre
    Given la liste des livres est chargée
    When je sélectionne "Fantastique" dans la liste des genres
    Then seuls les livres du genre "Fantastique" sont affichés

 Scenario: Rechercher un livre par public
    Given la liste des livres est chargée
    When je sélectionne "Adultes" dans la liste des public
    Then seuls les livres du public "Adultes" sont affichés

 Scenario: Rechercher un livre par rayon
    Given la liste des livres est chargée
    When je sélectionne "Magazines" dans la liste des rayons
    Then seuls les livres du rayon "Magazines" sont affichés

  