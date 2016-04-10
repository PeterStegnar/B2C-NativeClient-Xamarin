# Cross Platform Xamarin.Forms 2.0 ToDoList client with Azure AD B2C authentication

WORK IN PROGRESS...

Status 2016-04-09: sign in running with Droid + all Windows

# Links
- https://blog.xamarin.com/put-adal-xamarin-forms/

# ADAL v4 for each project in solution
- install-package Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory -pre


# GIT do not commit client/app settings 
- git update-index --assume-unchanged "TodoList_Client\TodoList_Client\Globals.cs"
- git update-index --no-assume-unchanged "TodoList_Client\TodoList_Client\Globals.cs"