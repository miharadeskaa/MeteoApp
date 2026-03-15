using Xunit;
using MeteoApp.Helpers;

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
}