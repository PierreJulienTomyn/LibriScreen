using LibriScreen.Services;
using LibriScreen.UI;
using LibriScreen.Interfaces;

/// <summary>
/// Classe principale du programme qui initialise les composants nécessaires et lance l'interface utilisateur.
/// </summary>
class Program
{
    /// <summary>
    /// Point d'entrée principal du programme.
    /// </summary>
    /// <param name="args">Arguments de la ligne de commande.</param>
    static void Main(string[] args)
    {
        // Création d'une instance de stockage de données utilisant le format JSON,
        // spécifiant le chemin du fichier où les données sont enregistrées.
        IDataStorage dataStorage = new JsonDataStorage("Data/mediaData.json");

        // Création du gestionnaire de médias, reliant le stockage de données au système de gestion.
        IMediaManager mediaManager = new MediaManager(dataStorage);

        // Initialisation de l'interface utilisateur avec le gestionnaire de médias.
        UserInterface ui = new UserInterface(mediaManager);

        // Démarrage de l'interface utilisateur et affichage du menu principal.
        ui.ShowMainMenu();
    }
}
