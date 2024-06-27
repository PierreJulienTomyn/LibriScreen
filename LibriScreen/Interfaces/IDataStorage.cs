using LibriScreen.Models;
using System.Collections.Generic;

// Espace de noms pour les interfaces utilisées dans la gestion des données de l'application LibriScreen
namespace LibriScreen.Interfaces
{
    /// <summary>
    /// Interface pour la gestion du stockage des données.
    /// Fournit des méthodes pour enregistrer et charger les éléments médias.
    /// </summary>
    public interface IDataStorage
    {
        /// <summary>
        /// Enregistre une collection d'éléments médias dans le stockage.
        /// </summary>
        /// <param name="items">Les éléments médias à enregistrer.</param>
        void SaveItems(IEnumerable<MediaItem> items);

        /// <summary>
        /// Charge les éléments médias depuis le stockage.
        /// </summary>
        /// <returns>Une collection d'éléments médias chargés depuis le stockage.</returns>
        IEnumerable<MediaItem> LoadItems();
    }
}
