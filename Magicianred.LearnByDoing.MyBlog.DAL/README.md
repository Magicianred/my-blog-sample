# Magicianred.LearnByDoing.MyBlog.DAL  
The DAL project is the project that handle the communication with the database, retrieve data and insert, edit or delete these.  
The project use *Dapper* for communicate with the database.  

## Repositories  
- *DatabaseConnectionFactory*: It's the class that retrieve the right connection based on your configuration settings. This class is concerned with open a connection different for the Sql Server or MySql database. It implements *IDatabaseConnectionFactory*.  
- *PostsRepository*: This class handle the entity data *Post*. It implements *IPostsRepository* and it are these methods:  
    - *GetAll*: Retrieve all posts in database  
    - *GetById*: Retrieve the post with the id passed in args, or *null* if don't exists.  

