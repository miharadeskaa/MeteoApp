namespace MeteoApp.Helpers



{ 
// Ajout de la classe MeteoLogic pour les tests unitaires
    public class MeteoLogic
    {
        public static string ObtenirCouleurTemperature(double temp)
        {
            if (temp <= 5) return "bg-info text-dark"; // Froid
            if (temp <= 15) return "bg-success";        // Frais
            if (temp <= 25) return "bg-warning text-dark"; // Doux
            return "bg-danger"; // Chaud
        }
    }



// Ajout de la classe NomVilleLogic pour les tests unitaires 
    public class NomVilleLogic
    {
        public static bool SontVillesIdentiques(string ville1, string ville2)
        {
            // Correction : ajout de OrdinalIgnoreCase pour que "Paris" == "paris"
            return string.Equals(ville1, ville2, StringComparison.OrdinalIgnoreCase);
        }
    }
}