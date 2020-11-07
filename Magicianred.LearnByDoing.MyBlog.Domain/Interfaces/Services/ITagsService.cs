using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services
{
    public interface ITagsService
    {
        public List<Tag> GetAll();
        public Tag GetById(int id);
    }
}
