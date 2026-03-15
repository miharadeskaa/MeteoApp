using Blazored.LocalStorage;
using MeteoApp.Models;

namespace MeteoApp.Services
{
    public class FavorisServices
    {
        private readonly ILocalStorageService _localStorage;
        private const string StorageKey = "favoris_meteo";

        public FavorisServices(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // 1. RÉCUPÉRER : On ne filtre que les favoris de l'utilisateur connecté
        public async Task<List<Favoris>> GetFavorisAsync(string userName)
        {
            var allFavoris = await _localStorage.GetItemAsync<List<Favoris>>(StorageKey) ?? new List<Favoris>();
            return allFavoris.Where(f => f.UserName == userName).ToList();
        }

        // 2. ENREGISTRER / MODIFIER
        public async Task SaveFavoriteAsync(Favoris favori)
        {
            var allFavoris = await _localStorage.GetItemAsync<List<Favoris>>(StorageKey) ?? new List<Favoris>();

            // On cherche si ce favori (même ID) existe déjà
            var index = allFavoris.FindIndex(f => f.Id == favori.Id);

            if (index != -1)
            {
                // Mise à jour (Update)
                allFavoris[index] = favori;
            }
            else
            {
                // Nouvel ajout
                allFavoris.Add(favori);
            }

            await _localStorage.SetItemAsync(StorageKey, allFavoris);
        }

        // 3. SUPPRIMER
        public async Task DeleteFavoriteAsync(Guid id)
        {
            var allFavoris = await _localStorage.GetItemAsync<List<Favoris>>(StorageKey) ?? new List<Favoris>();
            var itemToRemove = allFavoris.FirstOrDefault(f => f.Id == id);

            if (itemToRemove != null)
            {
                allFavoris.Remove(itemToRemove);
                await _localStorage.SetItemAsync(StorageKey, allFavoris);
            }
        }
    }
}