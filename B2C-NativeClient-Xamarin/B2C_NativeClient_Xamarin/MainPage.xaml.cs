using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using System.Net.Http;

namespace B2C_NativeClient_Xamarin
{
	public partial class MainPage : ContentPage
	{
        private HttpClient httpClient = new HttpClient();
        private AuthenticationContext authContext = null;

        public MainPage ()
		{
			InitializeComponent ();

            authContext = new AuthenticationContext(Globals.aadInstance + Globals.tenant);
        }

        void OnSignIn(object sender, EventArgs e)
        {

        }

        void OnSignUp(object sender, EventArgs e)
        {

        }

    }
}
