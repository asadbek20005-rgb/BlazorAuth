using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorAuth.Services
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly LocalStorage _storage;
        private readonly JwtSecurityTokenHandler _securityTokenHandler = new JwtSecurityTokenHandler();
        public CustomAuthProvider(LocalStorage localStorage)
        {
            _storage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claimPrincipal = await ReadToken();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimPrincipal)));
            return new AuthenticationState(claimPrincipal);
        }

        private async Task<ClaimsPrincipal> ReadToken()
        {
            var token = await _storage.GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return new ClaimsPrincipal(new ClaimsIdentity());
            }

            var securityToken = _securityTokenHandler.ReadJwtToken(token);
            var (userId, username, role) = GetClaims(securityToken);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.GivenName, username),
                new Claim(ClaimTypes.Role, role)
            };
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuth"));
            return claimPrincipal;
        }

        private Tuple<string?, string?, string?> GetClaims(JwtSecurityToken securityToken)
        {
            var userId = securityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var username = securityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)!.Value;
            var role = securityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value;
            return new(userId, username, role);
        }
    }
}
