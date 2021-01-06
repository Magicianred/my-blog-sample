using Dapper;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    /// <summary>
    /// Repository of categories
    /// </summary>
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabaseConnectionFactory _connectionFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CategoriesRepository(IDatabaseConnectionFactory connectionFactory, IConfiguration configuration)
        {
            this._configuration = configuration;
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

        public IEnumerable<Category> GetPaginatedAll(int page, int pageSize)
        {
            IEnumerable<Category> categories = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                var databaseType = _configuration.GetSection("DatabaseType").Value;
                if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
                {
                    categories = connection.Query<Category>("SELECT Id, Name, Description FROM Categories ORDER BY CreateDate DESC LIMIT @offset, @pageSize ",
                        new { offset = ((page - 1) * pageSize), pageSize = pageSize });
                }
                else // if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mssql")
                {
                    categories = connection.Query<Category>("SELECT Id, Name, Description FROM Categories ORDER BY CreateDate DESC OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY",
                            new { offset = ((page - 1) * pageSize), pageSize = pageSize });
                }
            }
            return categories;
        }


        /// <summary>
        /// Retrieve category by own id
        /// </summary>
        /// <param name="id">id of the category to retrieve</param>
        /// <returns>the category, null if id not found</returns>
        public Category GetById(int id, int page = 1, int pageSize = 3)
        {
            Category category = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                category = connection.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE Id = @CategoryId", new { CategoryId = id });
              
                // if category is not null, retrieve all posts of the category
                if(category != null)
                {
                    var databaseType = _configuration.GetSection("DatabaseType").Value;
                    if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mssql")
                    {
                        category.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE CategoryId = @CategoryId ORDER BY CreateDate DESC OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY",
                                new { CategoryId = id, offset = ((page - 1) * pageSize), pageSize = pageSize }).ToList();
                    }
                    else // if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
                    {
                        category.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE CategoryId = @CategoryId ORDER BY CreateDate DESC LIMIT @offset, @pageSize ",
                            new { CategoryId = id, offset = ((page - 1) * pageSize), pageSize = pageSize }).ToList();
                    }

                }
            }
            return category;
        }
    }
}
