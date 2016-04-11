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

            signinButton.IsVisible = true;
            signupButton.IsVisible = true;
            refreshButton.IsVisible = false;
            todoEntryGroup.IsVisible = false;
        }

        async Task getTodoList()
        {
            HttpResponseMessage response = await httpClient.GetAsync(Globals.todoListBaseAddress + "/api/todolist");
            if (response.IsSuccessStatusCode)
            {
                
            }
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            try
            {
                var result = await DependencyService.Get<IAuthenticator>().GetTokenSilent();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(result.TokenType, result.Token);

                await getTodoList();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok", "Cancel");
            }
        }

        async void OnAdd(object sender, EventArgs e)
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
            signinButton.IsVisible = false;
            signupButton.IsVisible = false;
            refreshButton.IsVisible = true;
            todoEntryGroup.IsVisible = true;
        }

        async void OnSignUp(object sender, EventArgs e)
        {
            var result = await DependencyService.Get<IAuthenticator>().Authenticate(Globals.signUpPolicy);
            UsernameLabel.Text = result.UserInfo.Name;
            signinButton.IsVisible = false;
            signupButton.IsVisible = false;
            refreshButton.IsVisible = true;
            todoEntryGroup.IsVisible = true;
        }

    }
}
