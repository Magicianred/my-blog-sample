using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories
{
    public interface ITagsRepository
    {
        public IEnumerable<Tag> GetAll();
        Tag GetById(int id);
    }
}
