// fichgier temporaire pour la logique métier de l'application météo


namespace MeteoApp.Helpers
{
    public class MeteoLogic
    {
        public static string ObtenirCouleurTemperature(double temp)
        {
            if (temp <= 5) return "bg-info text-dark"; // Froid
            if (temp > 5 && temp <= 15) return "bg-success"; // Frais
            if (temp > 15 && temp <= 25) return "bg-warning text-dark"; // Doux
            return "bg-danger"; // Chaud
        }
    }
}