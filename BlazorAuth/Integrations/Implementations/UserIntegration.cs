using BlazorAuth.Integrations.Interfaces;
using BlazorAuth.Models;
using System.Net;
using System.Net.Http.Json;

namespace BlazorAuth.Integrations.Implementations
{
    public class UserIntegration : IUserIntegration
    {
        private readonly HttpClient _httpClient;
        public UserIntegration(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Tuple<HttpStatusCode, string>> Login(LoginModel loginModel)
        {
            string url = "api/users/login";
            var response = await _httpClient.PostAsJsonAsync(url, loginModel);
            var token = await response.Content.ReadAsStringAsync();
            return new(response.StatusCode, token);
        }
    }
}