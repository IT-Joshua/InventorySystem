using Frontend.Components.Models;
using System.Net;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;


namespace Frontend.Client
{
    public class LoginClients
    {
        private readonly HttpClient _httpClient;
        private readonly ProtectedLocalStorage _localStorage;

        public LoginClients(HttpClient httpClient, ProtectedLocalStorage localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;

        }

        public async Task SetAuthorizeHeader()
        {
            var token = (await _localStorage.GetAsync<string>("authToken")).Value;
            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<RegisterResult> RegisterUserAsync(CreateAccountModels newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("User/register", newUser);

            // If success (200)
            if (response.IsSuccessStatusCode)
            {
                return new RegisterResult
                {
                    IsSuccess = true
                };
            }

            // If BadRequest (400)
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var error = await response.Content.ReadAsStringAsync();

                return new RegisterResult
                {
                    IsSuccess = false,
                    ErrorMessage = error
                };
            }

            // Optional fallback (just in case)
            return new RegisterResult
            {
                IsSuccess = false,
                ErrorMessage = "Unexpected error."
            };
        }

        public async Task<LoginResult> LoginUserAsync(LoginCredentials credentials)
        {
            var response = await _httpClient.PostAsJsonAsync("User/login", credentials);

            // Handle success (200 OK)
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<Tokens>()
                            ?? throw new InvalidOperationException("Empty response from server.");
                
                return new LoginResult
                {
                    IsSuccess = true,
                    Tokens = token
                };
            }

            // Handle BadRequest (400)
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return new LoginResult
                {
                    IsSuccess = false,
                    ErrorMessage = errorMessage
                };
            }

            // Fallback for unexpected errors
            return new LoginResult
            {
                IsSuccess = false,
                ErrorMessage = $"Unexpected error: {response.StatusCode}"
            };
        }

        
        public async Task<string?> GetAuthStatusAsync()
        {
            await SetAuthorizeHeader();

            var response = await _httpClient.GetAsync("User/Auth");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            // Optionally, throw or handle error
            var error = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed: {response.StatusCode}, {error}");
        }
        
        // public async Task<List<LogInModels>> GetUsersAsync(string username)
        // {
        //     var users = await _httpClient.GetFromJsonAsync<List<LogInModels>>($"user/{username}/login");

        //     return users;
        // }



        // public async Task<bool> CreateUserAsync(CreateAccountModels model)
        // {
        //     var response = await _httpClient.PostAsJsonAsync("user", model, new JsonSerializerOptions
        //     {
        //         PropertyNamingPolicy = null
        //     });
        //     return response.IsSuccessStatusCode;
        // }
    }
}