using LibriScreen.Interfaces;
using LibriScreen.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibriScreen.UI
{
    /// <summary>
    /// Classe interface utilisateur pour interagir avec le système de gestion de médias.
    /// </summary>
    public class UserInterface
    {
        private readonly IMediaManager _mediaManager; // Gestionnaire de médias pour les opérations sur les médias.

        /// <summary>
        /// Constructeur qui initialise l'interface utilisateur avec un gestionnaire de médias.
        /// </summary>
        /// <param name="mediaManager">Gestionnaire de médias.</param>
        public UserInterface(IMediaManager mediaManager)
        {
            _mediaManager = mediaManager;
        }

        /// <summary>
        /// Affiche le menu principal de l'application.
        /// </summary>
        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("LibriScreen - Menu Principal");
                Console.WriteLine("1. Ajouter un média");
                Console.WriteLine("2. Voir tous les médias");
                Console.WriteLine("3. Mettre à jour un média");
                Console.WriteLine("4. Supprimer un média");
                Console.WriteLine("5. Rechercher des médias");
                Console.WriteLine("6. Quitter");
                Console.Write("Sélectionnez une option : ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowAddNewItem();
                        break;
                    case "2":
                        DisplayItems(_mediaManager.GetAllItems());
                        break;
                    case "3":
                        ShowUpdateItem();
                        break;
                    case "4":
                        ShowDeleteItem();
                        break;
                    case "5":
                        ShowSearch();
                        break;
                    case "6":
                        return; // Quitte la boucle du menu
                    default:
                        Console.WriteLine("Option invalide, veuillez réessayer.");
                        break;
                }

                Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Affiche et gère l'ajout d'un nouvel élément média.
        /// </summary>
        public void ShowAddNewItem()
        {
            Console.Clear();
            var item = new MediaItem();

            Console.Write("Titre : ");
            item.Title = Console.ReadLine() ?? throw new ArgumentException("Le titre est obligatoire.");
            while (string.IsNullOrWhiteSpace(item.Title))
            {
                Console.WriteLine("Le titre est obligatoire. Veuillez entrer un titre : ");
                item.Title = Console.ReadLine() ?? throw new ArgumentException("Le titre est obligatoire.");
            }

            Console.Write("Genre : ");
            item.Genre = Console.ReadLine() ?? throw new ArgumentException("Le genre est obligatoire.");
            while (string.IsNullOrWhiteSpace(item.Genre))
            {
                Console.WriteLine("Le genre est obligatoire. Veuillez entrer un genre : ");
                item.Genre = Console.ReadLine() ?? throw new ArgumentException("Le genre est obligatoire.");
            }

            Console.Write("Note personnelle (0 à 10) : ");
            item.Rating = double.TryParse(Console.ReadLine(), out double rating) ? rating : throw new ArgumentException("Note invalide.");

            Console.Write("Date de visionnage/lecture (YYYY-MM-DD) : ");
            item.DateWatchedOrRead = DateTime.TryParse(Console.ReadLine(), out DateTime dateWatchedOrRead) ? dateWatchedOrRead : throw new ArgumentException("Date invalide.");

            Console.Write("Type de média (Film, Série, Livre) : ");
            item.MediaType = Enum.TryParse(Console.ReadLine(), true, out MediaType mediaType) ? mediaType : throw new ArgumentException("Type de média invalide.");

            _mediaManager.AddItem(item);
            Console.WriteLine("Média ajouté avec succès !");
        }

        /// <summary>
        /// Affiche et gère la mise à jour d'un élément média existant.
        /// </summary>
        public void ShowUpdateItem()
        {
            Console.Clear();
            Console.Write("Entrez l'ID du média à mettre à jour : ");
            int id = int.TryParse(Console.ReadLine(), out int mediaId) ? mediaId : throw new ArgumentException("ID invalide.");

            var existingItem = _mediaManager.GetAllItems().FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                Console.WriteLine("Aucun média trouvé avec cet ID.");
                return;
            }

            var updatedItem = new MediaItem { Id = id };

            Console.Write($"Titre ({existingItem.Title}) : ");
            var newTitle = Console.ReadLine();
            updatedItem.Title = string.IsNullOrWhiteSpace(newTitle) ? existingItem.Title : newTitle;

            Console.Write($"Genre ({existingItem.Genre}) : ");
            var newGenre = Console.ReadLine();
            updatedItem.Genre = string.IsNullOrWhiteSpace(newGenre) ? existingItem.Genre : newGenre;

            Console.Write($"Note personnelle ({existingItem.Rating}) : ");
            var newRatingStr = Console.ReadLine();
            updatedItem.Rating = double.TryParse(newRatingStr, out double newRating) ? newRating : existingItem.Rating;

            Console.Write($"Date de visionnage/lecture ({existingItem.DateWatchedOrRead:yyyy-MM-dd}) : ");
            var newDateStr = Console.ReadLine();
            updatedItem.DateWatchedOrRead = DateTime.TryParse(newDateStr, out DateTime newDate) ? newDate : existingItem.DateWatchedOrRead;

            Console.Write($"Type de média ({existingItem.MediaType}) : ");
            var newMediaTypeStr = Console.ReadLine();
            updatedItem.MediaType = Enum.TryParse(newMediaTypeStr, true, out MediaType newMediaType) ? newMediaType : existingItem.MediaType;

            _mediaManager.UpdateItem(id, updatedItem);
            Console.WriteLine("Média mis à jour avec succès !");
        }

        /// <summary>
        /// Affiche et gère la suppression d'un élément média.
        /// </summary>
        public void ShowDeleteItem()
        {
            Console.Clear();
            Console.Write("Entrez l'ID du média à supprimer : ");
            int id = int.TryParse(Console.ReadLine(), out int mediaId) ? mediaId : throw new ArgumentException("ID invalide.");

            _mediaManager.DeleteItem(id);
            Console.WriteLine("Média supprimé avec succès !");
        }

        /// <summary>
        /// Affiche et gère la recherche de médias basée sur un terme de recherche.
        /// </summary>
        public void ShowSearch()
        {
            Console.Clear();
            Console.Write("Entrez un terme de recherche : ");
            string searchTerm = Console.ReadLine() ?? throw new ArgumentException("Le terme de recherche est obligatoire.");

            var results = _mediaManager.SearchItems(searchTerm);
            DisplayItems(results);
        }

        /// <summary>
        /// Affiche les détails des éléments médias.
        /// </summary>
        /// <param name="items">Collection des éléments médias à afficher.</param>
        public void DisplayItems(IEnumerable<MediaItem> items)
        {
            Console.Clear();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Titre: {item.Title}, Genre: {item.Genre}, Note: {item.Rating}, Date: {item.DateWatchedOrRead:yyyy-MM-dd}, Type: {item.MediaType}");
            }
        }
    }
}
