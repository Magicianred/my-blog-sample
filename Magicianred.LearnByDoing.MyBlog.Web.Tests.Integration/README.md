# Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration  
This is the project with Integration Tests for the Web project.  

## How to use  

## Configure  

1. Create in root folder a file *testsettings.json* and past this text, change YOUR_CONNECTION_STRING with the connection string of your db test  
```json
{
    "ConnectionStrings": { "myBlog": "YOUR_CONNECTION_STRING" }
}
```

### From Visual Studio  
Open the *Test Explorer* window (from the menu *TEST* -> *Test explorer*)  select a specific test or run all.  

### From Visual studio code  
Open the terminal and digit
```cmd
dotnet test
```

