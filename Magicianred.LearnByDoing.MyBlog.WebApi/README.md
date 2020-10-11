# WebApi Application  
Namespace *Magicianred.LearnByDoing.MyBlog.WebApi*  

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
