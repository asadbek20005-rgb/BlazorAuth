using Blazored.LocalStorage;

namespace BlazorAuth.Services
{
    public class LocalStorage
    {
        private readonly ILocalStorageService _localStorageService;
        private const string _key = "token";
        public LocalStorage(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SetToken(string token)
        {
           await _localStorageService.SetItemAsync(_key, token);
        }

        public async Task<string?> GetToken()
        {
            var token = await _localStorageService.GetItemAsync<string>(_key);
            return token;
        }
    }
}
