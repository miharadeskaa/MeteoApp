using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MeteoApp; 
using Blazored.LocalStorage;
using MeteoApp.Services;   

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Le HttpClient par défaut généré par Blazor
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



// 1. Activer le stockage local
builder.Services.AddBlazoredLocalStorage();

// 2. Enregistrer vos services personnalisés
builder.Services.AddScoped<MeteoApiServices>();
builder.Services.AddScoped<FavorisServices>();
builder.Services.AddScoped<login>();


// --- FIN DE VOS AJOUTS ---

await builder.Build().RunAsync();
 
  
   
   