using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services
{
    public interface IPostsService
    {
        public List<Post> GetAll();
        public List<Post> GetAllByAuthor(string author);
        public Post GetById(int id);
    }
}
