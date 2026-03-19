using Blazored.LocalStorage;

namespace MeteoApp.Services
{
    public class LoginService 
    {
        // On rend le service de stockage optionnel avec le '?' pour ne pas faire planter les tests
        private readonly ILocalStorageService? _localStorage;
        private const string StorageKey = "users_db";



        // On utilise un dictionnaire pour stocker les utilisateurs et leurs mots de passe
        private Dictionary<string, string> _utilisateursValides = new()
        {
            { "admin", "Admin@2026" },
            { "jeremy", "Meteo123" },
            { "mika", "1234" },
            { "test", "test" }
        };


        // Propriétés pour suivre l'état de connexion
        public bool IsLoggedIn { get; private set; } = false;
        public string UserName { get; private set; } = "";
        public string MessageErreur { get; private set; } = "";
        public event Action? OnChange;




        // Le constructeur accepte un service de stockage local  
        public LoginService(ILocalStorageService? localStorage = null)
        {
            _localStorage = localStorage;
        }


        // Méthode pour initialiser les utilisateurs à partir du stockage local
        public async Task InitialiserAsync()
        {
            if (_localStorage == null) return; 

            var savedUsers = await _localStorage.GetItemAsync<Dictionary<string, string>>(StorageKey);
            if (savedUsers != null)
            {
                foreach (var user in savedUsers)
                {
                    if (!_utilisateursValides.ContainsKey(user.Key))
                        _utilisateursValides.Add(user.Key, user.Value);
                }
            }
        }


        // Méthode pour inscrire un nouvel utilisateur
        public async Task<bool> InscrireAsync(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password)) return false;

            string nomMin = name.ToLower();
            if (_utilisateursValides.ContainsKey(nomMin))
            {
                MessageErreur = "Cet utilisateur existe déjà.";
                return false;
            }

            _utilisateursValides.Add(nomMin, password);

            
        // On ne sauvegarde que si le stockage est disponible
            if (_localStorage != null)
            {
                await _localStorage.SetItemAsync(StorageKey, _utilisateursValides);
            }
            return true;
        }
        // Méthode pour vérifier les identifiants de connexion
        public bool Login(string name, string password)
        {
            MessageErreur = "";
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password)) return false;

            string nomMin = name.ToLower();
            
            if (_utilisateursValides.ContainsKey(nomMin) && _utilisateursValides[nomMin] == password)
            {
                IsLoggedIn = true;
                UserName = name;
                NotifyStateChanged();
                return true;
            }

            MessageErreur = "Identifiants incorrects.";
            return false;
        }


        // Méthode pour se déconnecter
        public void Logout()
        {
            IsLoggedIn = false;
            UserName = "";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}