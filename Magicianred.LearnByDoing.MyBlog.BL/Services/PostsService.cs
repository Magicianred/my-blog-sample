using Magicianred.LearnByDoing.MyBlog.DAL.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.BL.Services
{
    /// <summary>
    /// Service of posts
    /// </summary>
    public class PostsService : IPostsService
    {
        private IPostsRepository _postsRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <returns>list of posts</returns>
        public List<Post> GetAll()
        {
            return _postsRepository.GetAll().ToList();
        }

        /// <summary>
        /// Retrieve the post by own id
        /// </summary>
        /// <param name="id">id of post to retrieve</param>
        /// <returns>the post, null if id not found</returns>
        public Post GetById(int id)
        {
            return _postsRepository.GetById(id);
        }

    }
}
