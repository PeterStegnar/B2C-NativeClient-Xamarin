# Cross Platform Xamarin.Forms 2.0 ToDoList client with Azure AD B2C authentication
This sample is in terms of authentication adapted for B2C from https://blog.xamarin.com/put-adal-xamarin-forms/. 

# Status
WORK IN PROGRESS...
Status 2016-04-09: sign in running with Droid + all Windows

# ADAL v4 for each project in solution
- install-package Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory -pre

# GIT do not commit client/app settings 
- git update-index --assume-unchanged "TodoList_Client\TodoList_Client\Globals.cs"
- git update-index --assume-unchanged "TodoList_Service\Web.config"
- git update-index --assume-unchanged "TodoList_Service\Properties\PublishProfiles\..."

use --no-assume-unchanged to reserve
