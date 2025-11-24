using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

using Frontend.Components.Models;


namespace Frontend.Components.Client
{
    public class LoginClients
    {
        private readonly HttpClient _httpClient;

        public LoginClients(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<LogInModels>> GetUsersAsync(string username)
        {
            var users = await _httpClient.GetFromJsonAsync<List<LogInModels>>($"user/{username}/login");

            return users;
        }



        public async Task<bool> CreateUserAsync(CreateAccountModels model)
        {
            var response = await _httpClient.PostAsJsonAsync("user", model, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            });
            return response.IsSuccessStatusCode;
        }
    }
}