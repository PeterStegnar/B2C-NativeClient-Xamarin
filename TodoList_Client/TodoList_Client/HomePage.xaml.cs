using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TodoList_Client
{
    public partial class HomePage : ContentPage
    {
        private HttpClient httpClient = new HttpClient();

        public HomePage()
        {
            InitializeComponent();
        }

        async void Refresh()
        {
            try
            {
                var result = await DependencyService.Get<IAuthenticator>().GetTokenSilent();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.Token);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok", "Cancel");
            }
        }

        async void OnSignIn(object sender, EventArgs e)
        {
            var result = await DependencyService.Get<IAuthenticator>().Authenticate(Globals.signInPolicy);
            UsernameLabel.Text = result.UserInfo.Name;
        }

        async void OnSignUp(object sender, EventArgs e)
        {
            var result = await DependencyService.Get<IAuthenticator>().Authenticate(Globals.signUpPolicy);
            UsernameLabel.Text = result.UserInfo.Name;
        }

    }
}
