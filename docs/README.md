# LibriScreen

LibriScreen est une application console permettant de gérer vos médias (films, séries, livres) de manière simple et efficace.

## Fonctionnalités

- Ajouter un média
- Voir tous les médias
- Mettre à jour un média
- Supprimer un média
- Rechercher des médias

## Installation

Pour installer et exécuter l'application, assurez-vous d'avoir .NET 8.0 installé sur votre machine.

Clonez le dépôt :

```bash
git clone <URL_du_dépôt>
cd LibriScreen
```

## Utilisation

Pour exécuter l'application, utilisez la commande suivante :

```bash
dotnet run
```

Vous serez accueilli par un menu principal vous permettant de gérer vos médias.

## Fonctionnement de l'application

L'application est basée sur une interface utilisateur en console qui permet de gérer vos médias de manière interactive. Voici une description des fonctionnalités disponibles :

### Ajouter un média

Cette option permet d'ajouter un nouveau média à votre collection. Vous serez invité à entrer les informations suivantes :
- Titre
- Genre
- Note personnelle (0 à 10)
- Date de visionnage/lecture (au format YYYY-MM-DD)
- Type de média (Film, Série, Livre)

### Voir tous les médias

Cette option affiche une liste de tous les médias enregistrés dans votre collection.

### Mettre à jour un média

Cette option permet de mettre à jour les informations d'un média existant. Vous serez invité à entrer l'ID du média que vous souhaitez mettre à jour, puis vous pourrez modifier les informations suivantes :
- Titre
- Genre
- Note personnelle
- Date de visionnage/lecture
- Type de média

Si vous appuyez sur "Entrée" sans rien saisir, la valeur actuelle restera inchangée.

### Supprimer un média

Cette option permet de supprimer un média de votre collection. Vous serez invité à entrer l'ID du média que vous souhaitez supprimer.

### Rechercher des médias

Cette option permet de rechercher des médias dans votre collection en fonction d'un terme de recherche. Le terme de recherche sera comparé au titre et au genre des médias.

## Architecture

L'application suit les principes SOLID et le pattern de conception DRY. Elle est divisée en plusieurs classes et interfaces pour assurer une bonne séparation des responsabilités. Les classes sont organisées dans les dossiers `Service` et `UI` pour une meilleure structure du projet.

### Interfaces

- `IMediaManager` : Cette interface définit les opérations de gestion des médias, telles que l'ajout, la mise à jour, la suppression et la recherche de médias. Elle permet d'abstraire les détails de l'implémentation de la gestion des médias, facilitant ainsi le remplacement ou la modification de l'implémentation sans affecter le reste de l'application.
  
- `IDataStorage` : Cette interface définit les opérations de stockage des données, telles que la sauvegarde et le chargement des médias. Elle permet d'abstraire les détails de l'implémentation du stockage des données, facilitant ainsi le remplacement ou la modification de l'implémentation sans affecter le reste de l'application.

### Classes

#### Dossier `Models`

- `MediaItem` : Cette classe représente un élément média, avec des propriétés telles que l'ID, le titre, le genre, la note, la date de visionnage/lecture et le type de média. Elle encapsule les données relatives à un média et fournit une structure pour les manipuler.

#### Dossier `Services`

- `MediaManager` : Cette classe implémente l'interface `IMediaManager` et gère les opérations sur les médias, telles que l'ajout, la mise à jour, la suppression et la recherche de médias. Elle utilise un objet `IDataStorage` pour persister les données des médias. Cette classe contient la logique métier de l'application.

- `JsonDataStorage` : Cette classe implémente l'interface `IDataStorage` en utilisant des fichiers JSON pour le stockage des données. Elle gère la sérialisation et la désérialisation des objets `MediaItem` en JSON et assure la persistance des données dans un fichier.

#### Dossier `UI`

- `UserInterface` : Cette classe gère l'interaction avec l'utilisateur via la console. Elle affiche le menu principal, recueille les entrées de l'utilisateur, et appelle les méthodes appropriées de `MediaManager` pour effectuer les opérations demandées. Elle est responsable de l'expérience utilisateur de l'application.
