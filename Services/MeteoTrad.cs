namespace MeteoApp.Services
{
    public static class MeteoTrad
    {
        public static string GetDescription(int code)
        {
            return code switch
            {
                0 => "Ciel dégagé ☀️",
                1 or 2 or 3 => "Partiellement nuageux ⛅",
                45 or 48 => "Brouillard 🌫️",
                51 or 53 or 55 => "Bruine légère 🌦️",
                61 or 63 or 65 => "Pluie 🌧️",
                71 or 73 or 75 => "Neige ❄️",
                80 or 81 or 82 => "Averses de pluie ⛈️",
                95 or 96 or 99 => "Orage ⚡",
                _ => "Météo inconnue"
            };
        }
    }
}