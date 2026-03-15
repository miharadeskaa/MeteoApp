using System;

namespace MeteoApp.Models
{
    public class Favoris
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OriginalName { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        // --- Données modifiables localement ---
        
        public string UserName { get; set;} = "";
        public string CustomAlias { get; set; } = string.Empty; 
        public string PersonalNote { get; set; } = string.Empty; 
    }
}