using MudBlazor.Services;
using Frontend.Components;
using Frontend.Client;
using MudBlazor.Translations;
using Microsoft.AspNetCore.Components.Authorization;
using Frontend.Authentication;
using Frontend.Components.Pages;
var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
builder.Services.AddMudTranslations();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ApiUrl = builder.Configuration["ApiUrl"] ??
    throw new Exception("ApiUrl is not set");

builder.Services.AddHttpClient<LoginClients>(client => client.BaseAddress = new Uri(ApiUrl));
builder.Services.AddHttpClient<CompanyClient>(client => client.BaseAddress = new Uri(ApiUrl));

builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOutputCache();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapStaticAssets();
app.Run();
