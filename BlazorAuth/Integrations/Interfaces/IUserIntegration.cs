using BlazorAuth.Models;
using System.Net;

namespace BlazorAuth.Integrations.Interfaces
{
    public interface IUserIntegration
    {
        Task<Tuple<HttpStatusCode, string>> Login(LoginModel loginModel);
    }
}
