# Magicianred.LearnByDoing.MyBlog.WebApi  
This is the *web api* application. It is concerned with retrieve json data.  
Usually a *web api* project is consumed not by human but by other applications, specially client applications like *react*, *angular* or other javascript frameworks/libraries, but also client applications like *WPF* or other *MVC* and *web api*.  

## Description  
A WebApi Application in *asp.net webapi* core 3.1  

## Running Application

## Set your Connection string in the projects  
Set your dbtype and connection string in files appsettings.json (or better in appsettings.Development.json) - replace *DB_TYPE* and *YOUR_CONNECTION_STRING* with your connection string  
Possible dbtype:  
- "MsSQL" (default)  
- "MySQL"  
```json
{
  "DatabaseType": "DB_TYPE"
  "ConnectionStrings": {
    "myBlog": "YOUR_CONNECTION_STRING"
  }
}
```

### From Visual Studio
1. Setup your Database (in Folder DBScript you find the instruction)  
2. Set Project as Start Project  
3. Press *F5* to start DEBUG or you press debug button  

### From Visual Studio Code  
1. Open project folder (%your_path%\my-blog-sample\Magicianred.LearnByDoing.MyBlog.WebApi)  
2. Open New Terminal (if it's not open)  
3. Run the command:
```cmd
dotnet run 
```

## Use the endpoint for retrieve data  
When you have Running the application, you can open your browser and go to addresses (you have to accept the certificate):  
- *https://localhost:5001/api/home* - to show list of posts  
- *https://localhost:5001/api/home/{id}* - to show the post with {id}  

Enjoy your code!  


## Technical description  

### Controllers  
Controllers are the main component of the web api, it transforms data retrieves from *services* or *repositories* into *json* or *xml*.  
Controllers are composed by *actions* or *endpoints*.  
Actions are called in *rest* way, it means they are a *uri* and a *http verbs* (GET, POST, PUT, DELETE, etc.)  
- *HomeController* the main (and now unique) controller with these actions:  
  - *Get* [GET /api/home or /api/home/index] retrieve all posts     
  - *Get({id})* [GET /api/home/{id}] retrieve data of the post by *id*  



