using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;

namespace B2C_NativeClient_Xamarin
{
    // taken from https://blog.xamarin.com/put-adal-xamarin-forms/

    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string profileName);
        Task<AuthenticationResult> GetTokenSilent();
    }
}
