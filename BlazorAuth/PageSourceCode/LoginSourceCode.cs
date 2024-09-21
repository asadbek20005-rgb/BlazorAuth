using BlazorAuth.Integrations.Interfaces;
using BlazorAuth.Models;
using BlazorAuth.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorAuth.PageSourceCode
{
    public class LoginSourceCode : ComponentBase
    {
        [Inject]
        protected IUserIntegration UserIntegration { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected LocalStorage LocalStorage { get; set; }
        public LoginModel LoginModel = new LoginModel();
        public async Task LoginClicked()
        {


            await LocalStorage.SetToken(LoginModel.Token);
            NavigationManager.NavigateTo("/");

        }
    }
}
