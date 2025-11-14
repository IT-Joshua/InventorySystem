using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BlazorApp3.Models;
namespace BlazorApp3.Client
{
    public class LogInClient(HttpClient httpClient)
    {
        public async Task<LogInModels> GetCheckInsAsync(string Username)
        => await httpClient.GetFromJsonAsync<LogInModels>($"user/{Username}")
        ?? throw new Exception("User Not Found!");
    }
}