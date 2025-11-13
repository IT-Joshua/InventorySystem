using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorApp3.Models;
namespace BlazorApp3.Client

{
    public class LoginClient(HttpClient httpClient)
    {
        public async Task<LogInModels[]> GetLoginAsync(int id)
     => await httpClient.GetFromJsonAsync<LogInModels[]>($"/") ?? Array.Empty<LogInModels>();
    }
}