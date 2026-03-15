namespace MeteoApp.Services
{
    public class login
    {
        public bool IsLoggedIn { get; private set; } = false;
        public string UserName { get; private set; } = "";

        public event Action? OnChange;

        // On a ajouté le paramètre password
        public bool Login(string name, string password)
        {
            // Vérification simple (tu peux changer "1234")
            if (!string.IsNullOrWhiteSpace(name) && password == "1234")
            {
                IsLoggedIn = true;
                UserName = name;
                NotifyStateChanged();
                return true; // Connexion réussie
            }
            
            return false; // Connexion échouée
        }

        public void Logout()
        {
            IsLoggedIn = false;
            UserName = "";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}