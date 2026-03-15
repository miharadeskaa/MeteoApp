using System.Net.Http.Json;
using MeteoApp.Models;
using System.Globalization;

namespace MeteoApp.Services
{
    public class MeteoApiServices
    {
        private readonly HttpClient _httpClient;

        public MeteoApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // 1. MÉTHODE POUR CHERCHER LA MÉTÉO (VIA COORDONNÉES)
        public async Task<MeteoReponse?> GetWeatherAsync(double lat, double lon)
        {
            var latString = lat.ToString(CultureInfo.InvariantCulture);
            var lonString = lon.ToString(CultureInfo.InvariantCulture);

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latString}&longitude={lonString}&current_weather=true";
            
            return await _httpClient.GetFromJsonAsync<MeteoReponse>(url);
        }

        // 2. MÉTHODE POUR CHERCHER UNE VILLE 
        // CORRECTION ICI : On ajoute 'string Country' dans le Tuple de retour
        public async Task<(double Lat, double Lon, string Name, string Country,string CountryCode)?> SearchCityAsync(string cityName)
        {
            // API de géocodage d'Open-Meteo
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={cityName}&count=1&language=fr&format=json";
            
            var response = await _httpClient.GetFromJsonAsync<GeocodingResponse>(url);
            
            if (response?.Results != null && response.Results.Count > 0)
            {
                var city = response.Results[0];
                return (city.latitude, city.longitude, city.name, city.country, city.country_code); // Maintenant, ça correspond parfaitement !
            }
            
            return null;
        }
    }

    // CLASSES D'AIDE POUR LIRE LA RÉPONSE DU GÉOCODAGE
    public class GeocodingResponse 
    { 
        public List<GeocodingResult>? Results { get; set; } 
    }

    public class GeocodingResult 
    { 
        // PROPRIÉTÉS CORRESPONDANT AUX CHAMPS DE LA RÉPONSE DE L'API 
        public double latitude { get; set; } 
        public double longitude { get; set; } 
        public string name { get; set; } = ""; 

        // AJOUT DE CES DEUX PROPRIÉTÉS POUR LE PAYS
        public string country { get; set; } = ""; 
        public string country_code { get; set; } = "";
    }
}