# Magicianred.LearnByDoing.MyBlog.BL  
The BL project is concerned with the business logic of the application.  
It use the *Domain* project and the *DAL* project in order to handle data and manipulate it to produce the features that the application will do.  

## Services  
Services are classes that use repositories in order to queries the data and make somethings to manipulate it before returns them to the caller.  
- *PostsService*: This class handle the entity data *Post*. It implements *IPostsService* and it are these methods:  
    - *GetAll*: Retrieve all posts in database  
    - *GetById*: Retrieve the post with the id passed in args, or *null* if don't exists.  

