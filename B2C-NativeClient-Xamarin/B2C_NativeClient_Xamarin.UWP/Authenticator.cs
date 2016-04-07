using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

[assembly: Dependency(typeof(B2C_NativeClient_Xamarin.UWP.Authenticator))]
namespace B2C_NativeClient_Xamarin.UWP
{
    class Authenticator : IAuthenticator
    {
        AuthenticationContext authContext;
        public Authenticator()
        {
            authContext = new AuthenticationContext(Globals.aadInstance + Globals.tenant);
        }

        public async Task<AuthenticationResult> Authenticate(string profileName)
        {
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            var uri = new Uri(Globals.redirectUri);
            var platformParams = new PlatformParameters(PromptBehavior.Always, false);
            var authResult = await authContext.AcquireTokenAsync(new string[] { Globals.clientId },
                    null, Globals.clientId, new Uri(Globals.redirectUri),
                    platformParams, profileName);
            return authResult;
        }

        public async Task<AuthenticationResult> GetTokenSilent()
        {
            //// Try to get a token without triggering any user prompt. 
            //// ADAL will check whether the requested token is in the cache or can be obtained without user itneraction (e.g. via a refresh token).
            AuthenticationResult result = null;
            try
            {
                result = await authContext.AcquireTokenSilentAsync(new string[] { Globals.clientId }, Globals.clientId);
            }
            catch (AdalException ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += "Inner Exception : " + ex.InnerException.Message;
                }
                throw new Exception(message);
            }

            return result;
        }
    }

}
