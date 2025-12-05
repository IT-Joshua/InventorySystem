using System;
using System.Net.Http.Headers;
using Frontend.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Frontend.Client;

public class CompanyClient
{
    private readonly HttpClient _httpClient;
    private readonly ProtectedLocalStorage _localStorage;

    public CompanyClient(HttpClient httpClient, ProtectedLocalStorage localStorage)
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

    
     // Fetch company data from the API and return as CompanyDetails[]
   public async Task<CompanyDetails[]> GetCompaniesAsync()
    {
        await SetAuthorizeHeader();

        var response = await _httpClient.GetAsync("company/Ids");

        if (!response.IsSuccessStatusCode)
        {
            // Throw with status code
            throw new HttpRequestException(
                $"Request failed with status {response.StatusCode}",
                null,
                response.StatusCode
            );
        }

        return await response.Content.ReadFromJsonAsync<CompanyDetails[]>() ?? [];
    }
}
