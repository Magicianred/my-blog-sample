using Dapper;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    /// <summary>
    /// Repository of posts
    /// </summary>
    public class PostsRepository : IPostsRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public PostsRepository(IDatabaseConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Retrieve all Posts items
        /// </summary>
        /// <returns>list of post</returns>
        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> posts = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                posts = connection.Query<Post>("SELECT Id, Title, Text, Author FROM Posts ORDER BY CreateDate DESC");
            }
            return posts;
        }

        /// <summary>
        /// Retrieve all Posts items for specific author
        /// </summary>
        /// <returns>list of post</returns>
        public IEnumerable<Post> GetAllByAuthor(string author)
        {
            IEnumerable<Post> posts = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                posts = connection.Query<Post>("SELECT Id, Title, Text, Author FROM Posts WHERE Author = @Author ORDER BY CreateDate DESC",
                        new { Author = author });
            }
            return posts;
        }

        /// <summary>
        /// Retrieve post by own id
        /// </summary>
        /// <param name="id">id of the post to retrieve</param>
        /// <returns>the post, null if id not found</returns>
        public Post GetById(int id)
        {
            Post post = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                // TOP 1 is not a command for SQLite, remove
                post = connection.QueryFirstOrDefault<Post>("SELECT Id, Title, Text, Author, CategoryId FROM Posts WHERE Id = @PostId", new { PostId = id });

                // if post is not null, retrieve all tags of the post
                if (post != null)
                {
                    post.Tags = connection.Query<Tag>("SELECT * FROM Tags WHERE Id IN (SELECT TagId FROM PostTags WHERE PostId = @PostId)", 
                            new { PostId = id }).ToList();
                }
            }
            return post;
        }
    }
}
