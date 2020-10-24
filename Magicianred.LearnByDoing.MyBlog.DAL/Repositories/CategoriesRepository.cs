using Dapper;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    /// <summary>
    /// Repository of categories
    /// </summary>
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CategoriesRepository(IDatabaseConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Retrieve all Categories items
        /// </summary>
        /// <returns>list of categories</returns>
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                categories = connection.Query<Category>("SELECT Id, Name, Description FROM Categories ORDER BY CreateDate DESC");
            }
            return categories;
        }

        /// <summary>
        /// Retrieve category by own id
        /// </summary>
        /// <param name="id">id of the category to retrieve</param>
        /// <returns>the category, null if id not found</returns>
        public Category GetById(int id)
        {
            Category category = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                category = connection.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Id = @CategoryId", new { CategoryId = id });
              
                // if category is not null, retrieve all posts of the category
                if(category != null)
                {
                    category.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE CategoryId = @CategoryId", new { CategoryId = id }).ToList();
                }
            }
            return category;
        }
    }
}
