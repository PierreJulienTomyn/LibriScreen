using LibriScreen.Interfaces;
using LibriScreen.Models;
using System.Collections.Generic;
using System.Linq;

// Espace de noms pour les services de gestion de médias dans l'application LibriScreen
namespace LibriScreen.Services
{
    /// <summary>
    /// Service de gestion de médias qui implémente les fonctionnalités définies par l'interface IMediaManager.
    /// </summary>
    public class MediaManager : IMediaManager
    {
        private readonly IDataStorage _dataStorage; // Le système de stockage de données
        private List<MediaItem> _items; // Liste interne des éléments médias

        /// <summary>
        /// Constructeur pour MediaManager.
        /// </summary>
        /// <param name="dataStorage">Le service de stockage de données utilisé pour charger et enregistrer les médias.</param>
        public MediaManager(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
            _items = _dataStorage.LoadItems().ToList(); // Charge les éléments depuis le stockage
        }

        /// <summary>
        /// Ajoute un nouvel élément média à la liste et le sauvegarde.
        /// </summary>
        /// <param name="item">L'élément média à ajouter.</param>
        public void AddItem(MediaItem item)
        {
            item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1; // Attribue un ID unique
            _items.Add(item);
            _dataStorage.SaveItems(_items); // Sauvegarde la liste mise à jour
        }

        /// <summary>
        /// Met à jour un élément média existant et sauvegarde les modifications.
        /// </summary>
        /// <param name="id">L'ID de l'élément à mettre à jour.</param>
        /// <param name="updatedItem">Les nouvelles données pour l'élément.</param>
        public void UpdateItem(int id, MediaItem updatedItem)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Title = updatedItem.Title;
                item.Genre = updatedItem.Genre;
                item.Rating = updatedItem.Rating;
                item.DateWatchedOrRead = updatedItem.DateWatchedOrRead;
                item.MediaType = updatedItem.MediaType;
                _dataStorage.SaveItems(_items); // Sauvegarde les modifications
            }
        }

        /// <summary>
        /// Supprime un élément média de la liste et sauvegarde les modifications.
        /// </summary>
        /// <param name="id">L'ID de l'élément à supprimer.</param>
        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
                _dataStorage.SaveItems(_items); // Sauvegarde après suppression
            }
        }

        /// <summary>
        /// Récupère tous les éléments médias.
        /// </summary>
        /// <returns>Une collection de tous les éléments médias.</returns>
        public IEnumerable<MediaItem> GetAllItems()
        {
            return _items;
        }

        /// <summary>
        /// Récupère les éléments médias par type spécifié.
        /// </summary>
        /// <param name="type">Le type de média à filtrer.</param>
        /// <returns>Une collection d'éléments médias du type spécifié.</returns>
        public IEnumerable<MediaItem> GetItemsByType(MediaType type)
        {
            return _items.Where(i => i.MediaType == type);
        }

        /// <summary>
        /// Recherche des éléments médias selon un terme de recherche.
        /// </summary>
        /// <param name="searchTerm">Le terme de recherche.</param>
        /// <returns>Une collection d'éléments médias correspondant au terme de recherche.</returns>
        public IEnumerable<MediaItem> SearchItems(string searchTerm)
        {
            return _items.Where(i => 
                (i.Title != null && i.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (i.Genre != null && i.Genre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            );
        }

    }
}
