# my-blog-sample  
A simple blog for [learn-by-doing](https://github.com/Magicianred/learn-by-doing)  

## Instructions
### 1. Database  
1. Create a new Database in Sql Server  
2. Run scripts:  
	- 000_InitialScript.sql  
	- 000b_CreateUniqueCostraintForMigrationName.sql  
	- 001_create_posts_table.sql  

### 2. Set Connection string
Set your connection string in file appsettings.json (or better in appsettings.Development.json) - replace *YOUR_CONNECTION_STRING* with your connection string  
```json
  "ConnectionStrings": {
    "myBlog": "YOUR_CONNECTION_STRING"
  }
```

### 3. Run application
Set *Magicianred.LearnByDoing.MyBlog.Web* project as Startup Project and lanch debug  

