# my-blog-sample  
A simple blog for [learn-by-doing](https://github.com/Magicianred/learn-by-doing)  

## Instructions
### 1. Database  
Show the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/DBScripts/README.md) in DBScript folder.   

### 2. Set your Connection string in the projects  
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

### 3. Run applications
- For the *Web Application* set *Magicianred.LearnByDoing.MyBlog.<span/>Web* project as Startup Project and lanch debug or see the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.Web/README.md)  
- For the *Web Api Application* set *Magicianred.LearnByDoing.MyBlog.WebApi* project as Startup Project and lanch debug or see the [README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.WebApi/README.md)  

## About projects  

### Magicianred.LearnByDoing.MyBlog.Domain

This project contains the project infrastructure with all models and interfaces that used in the project.  
All projects references this project, but this project have no references to other projects.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.Domain/README.md)  

### Magicianred.LearnByDoing.MyBlog.DAL  
The DAL project is the project that handle the communication with the database, retrieve data and insert, edit or delete these.  
The project use *Dapper* for communicate with the database.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.DAL/README.md) 

### Magicianred.LearnByDoing.MyBlog.BL  
The BL project is concerned with the business logic of the application.  
It use the *Domain* project and the *DAL* project in order to handle data and manipulate it to produce the features that the application will do.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.BL/README.md)  

###  Magicianred.LearnByDoing.MyBlog<span>.</span>Web  
This is the web application. It is concerned with display data to the visitator of the web site.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.Web/README.md)  

### Magicianred.LearnByDoing.MyBlog.WebApi  
This is the *web api* application. It is concerned with retrieve json data.  
Usually a *web api* project is consumed not by human but by other applications, specially client applications like *react*, *angular* or other javascript frameworks/libraries, but also client applications like *WPF* or other *MVC* and *web api*.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.WebApi/README.md)  

### Tests Projects  
There are two types of tests:  
- *Unit tests*: there are test make in isolation (for example without a database) throws dependency inject and mocks objects.  
- *Integration tests*: there are test make, respect to unit tests, with real objects (for example with a real database create for the test, not with the production database!)  

#### Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit  
This is the project with Unit Tests for the DAL project.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit/README.md)  

#### Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit
This is the project with Unit Tests for the BL project.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit/README.md)  

#### Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration  
This is the project with Integration Tests for the Web project. 

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration/README.md)  

#### Magicianred.LearnByDoing.MyBlog.WebApi.Tests.Integration  
This is the project with Integration Tests for the WebApi project.  

[for details read README.md](https://github.com/Magicianred/my-blog-sample/blob/develop/Magicianred.LearnByDoing.MyBlog.WebApi.Tests.Integration/README.md)  