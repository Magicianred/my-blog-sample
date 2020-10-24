using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services
{
    public interface ICategoriesService
    {
        public List<Category> GetAll();
        public Category GetById(int id);
    }
}
