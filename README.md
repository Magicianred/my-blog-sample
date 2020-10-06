# my-blog-sample  
A simple blog for learn-by-doing  

## Create Database  
1. Create a new Database in Sql Server  
2. Run scripts:  
	- 000_InitialScript.sql  
	- 000b_CreateUniqueCostraintForMigrationName.sql  
	- 001_create_posts_table.sql  

## Connection string
Set your connection string in file appsettings.json (or better in appsettings.Development.json)
```json
  "ConnectionStrings": {
    "myBlog": "YOUR_CONNECTION_STRING"
  }
```

Set *Magicianred.LearnByDoing.MyBlog.Web* project as Startup Project and lanch debug  