using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BlazorApp3.Models;
using System.Text.Json;
namespace BlazorApp3.Client
{
    // public class LogInClient(HttpClient httpClient)
    // {
    //     public async Task<LogInModels> GetUsersAsync(string Username)
    //     => await httpClient.GetFromJsonAsync<LogInModels>($"user/{Username}")
    //     ?? throw new Exception("User Not Found!");
    // }
    public class LogInClient
    {
        private readonly HttpClient _httpClient;

        public LogInClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<LogInModels>> GetUsersAsync(string username)
        {
            var users = await _httpClient.GetFromJsonAsync<List<LogInModels>>($"user/{username}/login");
            if (users == null || users.Count == 0)
                throw new Exception("User not found");
            return users;
        }


        // public async Task<bool> CreateUserAsync(LogInModels model)
        // {
        //     var response = await _httpClient.PostAsJsonAsync("user", model);
        //     return response.IsSuccessStatusCode;
        // }
        public async Task<bool> CreateUserAsync(LogInModels model)
        {
            var response = await _httpClient.PostAsJsonAsync("user", model, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null   // important!
            });
            return response.IsSuccessStatusCode;
        }



    }
}