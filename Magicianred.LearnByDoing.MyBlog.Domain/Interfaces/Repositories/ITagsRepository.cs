using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories
{
    public interface ITagsRepository
    {
        public IEnumerable<Tag> GetAll();
        public IEnumerable<Tag> GetPaginatedAll(int page, int pageSize);
        Tag GetById(int id, int page = 1, int pageSize = 3);
    }
}
