using LibriScreen.Models;
using System.Collections.Generic;

// Espace de noms pour les interfaces utilisées dans l'application LibriScreen
namespace LibriScreen.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des médias.
    /// Permet de manipuler des items médias dans une application.
    /// </summary>
    public interface IMediaManager
    {
        /// <summary>
        /// Ajoute un nouvel élément média à la collection.
        /// </summary>
        /// <param name="item">L'élément média à ajouter.</param>
        void AddItem(MediaItem item);

        /// <summary>
        /// Met à jour un élément média existant.
        /// </summary>
        /// <param name="id">L'identifiant de l'élément média à mettre à jour.</param>
        /// <param name="updatedItem">L'élément média mis à jour.</param>
        void UpdateItem(int id, MediaItem updatedItem);

        /// <summary>
        /// Supprime un élément média de la collection.
        /// </summary>
        /// <param name="id">L'identifiant de l'élément à supprimer.</param>
        void DeleteItem(int id);

        /// <summary>
        /// Récupère tous les éléments médias de la collection.
        /// </summary>
        /// <returns>Une collection de tous les éléments médias.</returns>
        IEnumerable<MediaItem> GetAllItems();

        /// <summary>
        /// Récupère les éléments médias par type.
        /// </summary>
        /// <param name="type">Le type de média à filtrer.</param>
        /// <returns>Une collection d'éléments médias du type spécifié.</returns>
        IEnumerable<MediaItem> GetItemsByType(MediaType type);

        /// <summary>
        /// Recherche des éléments médias en fonction d'un terme de recherche.
        /// </summary>
        /// <param name="searchTerm">Le terme de recherche pour filtrer les éléments médias.</param>
        /// <returns>Une collection d'éléments médias qui correspondent au terme de recherche.</returns>
        IEnumerable<MediaItem> SearchItems(string searchTerm);
    }
}
