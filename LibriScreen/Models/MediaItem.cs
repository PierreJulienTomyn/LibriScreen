using System;

// Espace de noms pour les modèles utilisés dans l'application LibriScreen
namespace LibriScreen.Models
{
    /// <summary>
    /// Représente un élément média dans l'application.
    /// </summary>
    public class MediaItem
    {
        /// <summary>
        /// Identifiant unique de l'élément média.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de l'élément média.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Genre de l'élément média.
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Note attribuée à l'élément média.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Date à laquelle l'élément média a été regardé ou lu.
        /// </summary>
        public DateTime DateWatchedOrRead { get; set; }

        /// <summary>
        /// Type de média de l'élément, par exemple livre ou film.
        /// </summary>
        public MediaType MediaType { get; set; }
    }
}
