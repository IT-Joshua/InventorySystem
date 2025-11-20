// using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.JSInterop;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using System;
// using System.Collections.Generic;
// using System.Linq;




// namespace BlazorApp3.Data
// {
//     public class LocalStorageAuthStateProvider : AuthenticationStateProvider
//     {
//         private readonly IJSRuntime _js;

//         public LocalStorageAuthStateProvider(IJSRuntime js)
//         {
//             _js = js;
//         }

//         public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//         {
//             var savedUsername = await _js.InvokeAsync<string>("localStorage.getItem", "savedUsername");

//             ClaimsIdentity identity;

//             if (!string.IsNullOrEmpty(savedUsername))
//             {
//                 // User is logged in
//                 identity = new ClaimsIdentity(new[]
//                 {
//                         new Claim(ClaimTypes.Name, savedUsername)
//                     }, "localStorageAuth");
//             }
//             else
//             {
//                 // User not logged in
//                 identity = new ClaimsIdentity();
//             }

//             var user = new ClaimsPrincipal(identity);
//             return new AuthenticationState(user);
//         }

//         public void NotifyUserAuthentication(string username)
//         {
//             var identity = new ClaimsIdentity(new[]
//             {
//                     new Claim(ClaimTypes.Name, username)
//                 }, "localStorageAuth");

//             var user = new ClaimsPrincipal(identity);
//             NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
//         }

//         public void NotifyUserLogout()
//         {
//             var identity = new ClaimsIdentity();
//             var user = new ClaimsPrincipal(identity);
//             NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
//         }
//     }
// }