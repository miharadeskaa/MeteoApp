namespace MeteoApp.Services
{
    public class login
    {
        public bool IsLoggedIn { get; private set; } = false;
        public string UserName { get; private set; } = "";

        
        public event Action? OnChange;

        public void Login(string name)
        {
            IsLoggedIn = true;
            UserName = name;
            NotifyStateChanged();
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