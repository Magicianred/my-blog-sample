using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    /// <summary>
    /// Repository of posts
    /// </summary>
    public class PostsRepository : IPostsRepository
    {
        private string _connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public PostsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MyBlog");
        }

        /// <summary>
        /// Retrieve all Posts items
        /// </summary>
        /// <returns>list of post</returns>
        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> posts = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                posts = connection.Query<Post>("SELECT * FROM Posts ORDER BY CreateDate DESC");
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                post = connection.QueryFirstOrDefault<Post>("SELECT TOP 1 * FROM Posts WHERE Id = @PostId", new { PostId = id });
            }
            return post;
        }
    }
}
