using Xunit;
using MeteoApp.Helpers;
using MeteoApp.Pages;

namespace MeteoApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCouleurFroid()
        {
            // On teste si 2°C retourne bien la couleur bleue (bg-info)
            string resultat = MeteoLogic.ObtenirCouleurTemperature(2.0);
            Assert.Equal("bg-info text-dark", resultat);
        }

        [Fact]
        public void TestCouleurChaud()
        {
            // On teste si 30°C retourne bien la couleur rouge (bg-danger)
            string resultat = MeteoLogic.ObtenirCouleurTemperature(30.0);
            Assert.Equal("bg-danger", resultat);
        }
    }

    public class UnitTest2
    {
        
        
        [Fact]
        public void NomVilleLogicTest()
        {
            // On teste si les villes "Paris" et "Lyon" sont considérées comme différentes
            string ville1 = "Paris";
            string ville2 = "Lyon";
            bool resultat = NomVilleLogic.SontVillesIdentiques(ville1, ville2);
            Assert.False(resultat);
        }
    }
        // tester les logins
    public class UnitTest3
        {   
            [Fact]
            public void TestLoginValide()
            {
                // On teste si le login "admin" avec le mot de passe correct fonctionne
                var service = new MeteoApp.Services.LoginService();
                bool resultat = service.Login("admin", "Admin@2026");
                Assert.True(resultat);
                Assert.True(service.IsLoggedIn);
                Assert.Equal("admin", service.UserName);
            }

            [Fact]
            public void TestLoginInvalide()
            {
                // On teste si un login avec un mot de passe incorrect échoue
                var service = new MeteoApp.Services.LoginService();
                bool resultat = service.Login("admin", "wrongpassword");
                Assert.False(resultat);
                Assert.False(service.IsLoggedIn);
                Assert.Equal("", service.UserName);
            }
        }
        
}