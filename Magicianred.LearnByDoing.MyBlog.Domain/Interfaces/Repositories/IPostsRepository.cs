using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories
{
    public interface IPostsRepository
    {
        public IEnumerable<Post> GetAll();
        /// <summary>
        /// Retrieve all posts paginated
        /// </summary>
        /// <param name="page">current page</param>
        /// <param name="pageSize">items for page</param>
        /// <returns></returns>
        public IEnumerable<Post> GetPaginatedAll(int page, int pageSize);
        public IEnumerable<Post> GetAllByAuthor(string author);
        Post GetById(int id);
    }
}
