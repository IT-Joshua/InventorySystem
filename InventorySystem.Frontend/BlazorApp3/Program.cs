// using Microsoft.AspNetCore.Components.Web;
// using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// using BlazorApp3;
// using System.Net.Http.Json;
// using BlazorApp3.Client;
// using Microsoft.Extensions.FileProviders;

// var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// builder.Services.AddHttpClient<LogInClient>(client => client.BaseAddress = new Uri(WMSApiUrl));

// await builder.Build().RunAsync();



// using Microsoft.AspNetCore.Components.Web;
// using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// using BlazorApp3;
// using BlazorApp3.Client;
// using System.Net.Http.Json;
// using Microsoft.Extensions.FileProviders;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorComponents()
//                 .AddInteractiveServerComponents();
// builder.Services.AddBlazorBootstrap();

// // builder.RootComponents.Add<App>("#app");
// // builder.RootComponents.Add<HeadOutlet>("head::after");



// var WMSApiUrl = builder.Configuration["ApiUrl"] ??
//     throw new Exception("ApiUrl is not set");

// builder.Services.AddHttpClient<LogInClient>(client => client.BaseAddress = new Uri(WMSApiUrl));


// // builder.Services.AddHttpClient<LogInClient>(client =>
// // {
// //     client.BaseAddress = new Uri(ApiUrl);
// // });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error", createScopeForErrors: true);
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// // app.UseHttpsRedirection();

// app.UseStaticFiles();
// app.UseAntiforgery();

// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();

// app.Run();




using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp3;
using BlazorApp3.Client;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var ApiUrl = builder.Configuration["ApiUrl"] ??
    throw new Exception("ApiUrl is not set");

builder.Services.AddHttpClient<LogInClient>(client =>
    client.BaseAddress = new Uri(ApiUrl));

await builder.Build().RunAsync();