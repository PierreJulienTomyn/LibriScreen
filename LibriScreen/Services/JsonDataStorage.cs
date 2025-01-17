using LibriScreen.Interfaces;
using LibriScreen.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Espace de noms pour les services de stockage de données de l'application LibriScreen
namespace LibriScreen.Services
{
    /// <summary>
    /// Service de stockage de données qui utilise le format JSON pour enregistrer et charger les médias.
    /// </summary>
    public class JsonDataStorage : IDataStorage
    {
        private readonly string _filePath; // Chemin du fichier où les données sont stockées

        /// <summary>
        /// Constructeur pour JsonDataStorage.
        /// </summary>
        /// <param name="filePath">Chemin relatif du fichier JSON utilisé pour le stockage.</param>
        public JsonDataStorage(string filePath)
        {
            // Utiliser un chemin absolu basé sur le répertoire de l'application
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string absoluteFilePath = Path.Combine(appDirectory, filePath);

            // Mettre à jour le champ _filePath avec le chemin absolu
            _filePath = absoluteFilePath;

            // S'assurer que le répertoire existe
            string directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// Sauvegarde les éléments médias dans un fichier JSON.
        /// </summary>
        /// <param name="items">Collection d'éléments médias à sauvegarder.</param>
        public void SaveItems(IEnumerable<MediaItem> items)
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json); // Écriture du JSON formatté dans le fichier
        }

        /// <summary>
        /// Charge les éléments médias depuis un fichier JSON.
        /// </summary>
        /// <returns>Collection d'éléments médias chargés.</returns>
        public IEnumerable<MediaItem> LoadItems()
        {
            if (!File.Exists(_filePath))
                return new List<MediaItem>(); // Retourne une liste vide si le fichier n'existe pas

            string json = File.ReadAllText(_filePath);
            IEnumerable<MediaItem> items = JsonSerializer.Deserialize<IEnumerable<MediaItem>>(json);

            return items ?? new List<MediaItem>(); // Retourne une liste vide si la désérialisation retourne null
        }
    }
}
