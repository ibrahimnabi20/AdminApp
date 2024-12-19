using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AdminApp.Models;

namespace AdminApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            // Initializes the HttpClient with a base address for API calls
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/api/") };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            // Sends a GET request to fetch all users from the API
            var response = await _httpClient.GetAsync("users");
            response.EnsureSuccessStatusCode(); // Ensures the request was successful
            var json = await response.Content.ReadAsStringAsync();
            // Deserializes the JSON response into a list of User objects
            return JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteUserAsync(string userId)
        {
            // Sends a DELETE request to remove a user by ID
            var response = await _httpClient.DeleteAsync($"users/{userId}");
            response.EnsureSuccessStatusCode(); // Ensures the request was successful
        }
    }
}
