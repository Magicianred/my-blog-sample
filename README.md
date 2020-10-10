# my-blog-sample  
A simple blog for [learn-by-doing](https://github.com/Magicianred/learn-by-doing)  

## Instructions
### 1. Database  
Show the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/DBScripts/README.md) in DBScript folder.   

### 2. Set your Connection string in the projects  
Set your connection string in files appsettings.json (or better in appsettings.Development.json) - replace *YOUR_CONNECTION_STRING* with your connection string  
```json
  "ConnectionStrings": {
    "myBlog": "YOUR_CONNECTION_STRING"
  }
```

### 3. Run applications
- For the *Web Application* set *Magicianred.LearnByDoing.MyBlog.<span/>Web* project as Startup Project and lanch debug or see the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.Web/README.md)  
- For the *Web Api Application* set *Magicianred.LearnByDoing.MyBlog.WebApi* project as Startup Project and lanch debug or see the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.WebApi/README.md)  

