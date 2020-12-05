using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services
{
    public interface IPostsService
    {
        public List<Post> GetAll();
        /// <summary>
        /// Retrieve all posts paginated
        /// </summary>
        /// <param name="page">current page</param>
        /// <param name="pageSize">items for page</param>
        /// <returns></returns>
        public List<Post> GetPaginatedAll(int page, int pageSize);
        public List<Post> GetAllByAuthor(string author);
        public Post GetById(int id);
    }
}
