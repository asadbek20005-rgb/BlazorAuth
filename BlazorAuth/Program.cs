using BlazorAuth;
using BlazorAuth.Integrations.Implementations;
using BlazorAuth.Integrations.Interfaces;
using BlazorAuth.PageSourceCode;
using BlazorAuth.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7203/") });
builder.Services.AddScoped<IUserIntegration, UserIntegration>();
builder.Services.AddScoped<LocalStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
await builder.Build().RunAsync();