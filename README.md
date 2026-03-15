# 🌤️ MeteoApp - Projet Blazor WebAssembly

Application météo interactive développée en .NET 8, permettant de consulter la météo mondiale avec gestion des favoris et tests unitaires.

## ✨ Fonctionnalités
- **Recherche météo** : Consultation en temps réel via l'API OpenWeather.
- **Gestion des Favoris** : Ajout et suppression de villes favorites (stockées en LocalStorage).
- **Internationalisation** : Affichage des drapeaux des pays et noms des villes.
- **Interface Adaptive** : Couleurs dynamiques selon la température (froid, frais, chaud).

## 🧪 Tests Unitaires
Le projet inclut une suite de tests unitaires avec **xUnit** pour garantir la fiabilité de la logique métier.
- **Projet de test** : `MeteoApp.Tests`
- **Logique testée** : Calcul des couleurs CSS en fonction des températures (dossier `Helpers`).

Pour lancer les tests :
```bash
dotnet test