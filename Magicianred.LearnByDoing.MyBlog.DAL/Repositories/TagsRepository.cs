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
    /// Repository of tags
    /// </summary>
    public class TagsRepository : ITagsRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public TagsRepository(IDatabaseConnectionFactory connectionFactory)
        {
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

        /// <summary>
        /// Retrieve tag by own id
        /// </summary>
        /// <param name="id">id of the tag to retrieve</param>
        /// <returns>the tag, null if id not found</returns>
        public Tag GetById(int id)
        {
            Tag tag = null;
            using (var connection = _connectionFactory.GetConnection())
            {
                // TOP 1 is not a command for SQLite, remove
                tag = connection.QueryFirstOrDefault<Tag>("SELECT Id, Name, Description FROM Tags WHERE Id = @TagId", new { TagId = id });

                // if tag is not null, retrieve all post of the tag
                if (tag != null)
                {
                    tag.Posts = connection.Query<Post>("SELECT * FROM Posts WHERE Id IN (SELECT Id FROM PostTags WHERE TagId = @TagId)",
                            new { TagId = id }).ToList();
                }
            }
            return tag;
        }
    }
}
