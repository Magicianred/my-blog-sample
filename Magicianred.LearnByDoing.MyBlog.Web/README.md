# Magicianred.LearnByDoing.MyBlog.Web  
This is the web application. It is concerned with display data to the visitator of the web site.    

## Description  
A Web Application in *asp<span>.</span>net MVC* and *Razor* core 3.1  

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
1. Open project folder (%your_path%\my-blog-sample\Magicianred.LearnByDoing.MyBlog.Web)  
2. Open New Terminal (if it's not open)  
3. Run the command:
```cmd
dotnet run 
```

## Show application  
When you have Running the application, you can open your browser and go to address *https://localhost:5001* (you have to accept the certificate)  

Enjoy your code!  

## Technical description  

### Controllers  
Controllers are the main component of the MVC pattern, it handles the communication with the model and the view.  
- *HomeController* the main (and now unique) controller with these actions:  
  - *Index* shows a page with all posts  
  - *Post({id})* show a page with the post by *id*  
  - *About* show a page with some information of the project  
  - *Contact us* show a page with addesses to retrieve info and contact the author of the project  

### Models  
Models are the class that keep data. It's different of the Models with the *Domain* and *BL* projects, these are *presentation models* and are specifically designed for the *Views*.  
- *ErrorViewModel* is concerned to keep error data to show them at the final users.  

### Views  
*Views* transforms data in *HTML* markup language so that it's render to the browsers. We use *Razor* language to make this activity.  

- *Index* shows all posts  
- *Post* shows post details  
- *About* shows project informations  
- *Contact* shows a list of links  

#### Shared Views  
These are views used to all (or almost all) views to shared some code or logics.  
- *_Layout* is the base layout, the template of the site  
- *_ValidationScriptsPartial* keeps links to external scripts to make validations  
- *Error* is the view that show errors to the final users  
