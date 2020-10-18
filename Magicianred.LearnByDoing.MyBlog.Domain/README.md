# Magicianred.LearnByDoing.MyBlog.Domain

This project contains the project infrastructure with all models and interfaces that used in the project.  
All projects references this project, but this project have no references to other projects.  

## Interfaces  
The interfaces describe classes of the project and there are so useful with tests.  

### Models  
- *IPost* is the interface of entity *Post*.

### Repositories  
- *IDatabaseConnectionFactory* is a factory interface that return the right database connection.
- *IPostsRepository* is the interface for classes to handle Post entities.  

### Services  
- *IPostsService* is the interface for classes to handle Post entities.  

## Models  
- *Post* is the class to keep data of the entity Post.  
