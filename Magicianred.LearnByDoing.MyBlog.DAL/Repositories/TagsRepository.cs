using Dapper;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Repositories
{
    /// <summary>
    /// Repository of tags
    /// </summary>
    public class TagsRepository : ITagsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabaseConnectionFactory _connectionFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public TagsRepository(IDatabaseConnectionFactory connectionFactory, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Retrieve all Tags items
        /// </summary>
        /// <returns>list of tag</returns>
        public IEnumerable<Tag> GetAll()
        {
            IEnumerable<Tag> posts = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                posts = connection.Query<Tag>("SELECT Id, Name, Description FROM Tags ORDER BY CreateDate DESC");
            }
            return posts;
        }

        public IEnumerable<Tag> GetPaginatedAll(int page, int pageSize)
        {
            IEnumerable<Tag> posts = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                var databaseType = _configuration.GetSection("DatabaseType").Value;
                if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
                {
                    posts = connection.Query<Tag>("SELECT Id, Name, Description FROM Tags ORDER BY CreateDate  DESC LIMIT @offset, @pageSize ",
                        new { offset = ((page - 1) * pageSize), pageSize = pageSize });
                }
                else // if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mssql")
                {
                    posts = connection.Query<Tag>("SELECT Id, Name, Description FROM Tags ORDER BY CreateDate DESC OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY",
                            new { offset = ((page - 1) * pageSize), pageSize = pageSize });
                }
            }
            return posts;
        }

        /// <summary>
        /// Retrieve tag by own id
        /// </summary>
        /// <param name="id">id of the tag to retrieve</param>
        /// <returns>the tag, null if id not found</returns>
        public Tag GetById(int id, int page = 1, int pageSize = 3)
        {
            Tag tag = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                // TOP 1 is not a command for SQLite, remove
                tag = connection.QueryFirstOrDefault<Tag>("SELECT Id, Name, Description FROM Tags WHERE Id = @TagId", new { TagId = id });

                // if tag is not null, retrieve all post of the tag
                if (tag != null)
                {
                    var databaseType = _configuration.GetSection("DatabaseType").Value;
                    if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mssql")
                    {
                        tag.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE Id IN (SELECT PostId FROM PostTags WHERE TagId = @TagId ORDER BY CreateDate DESC OFFSET @offset ROWS FETCH NEXT @PageSize ROWS ONLY)",
                                new { TagId = id, offset = ((page - 1) * pageSize), pageSize = pageSize }).ToList();
                    }
                    else // if (!string.IsNullOrWhiteSpace(databaseType) && databaseType.ToLower().Trim() == "mysql")
                    {
                        tag.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE Id IN (SELECT PostId FROM PostTags WHERE TagId = @TagId ORDER BY CreateDate  DESC LIMIT @offset, @pageSize)",
                                new { TagId = id, offset = ((page - 1) * pageSize), pageSize = pageSize }).ToList();
                    }
                }
            }
            return tag;
        }
    }
}
