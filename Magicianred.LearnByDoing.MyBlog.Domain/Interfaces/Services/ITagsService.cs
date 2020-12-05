using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services
{
    public interface ITagsService
    {
        public List<Tag> GetAll();
        public List<Tag> GetPaginatedAll(int page = 1, int pageSize = 3);
        public Tag GetById(int id, int page = 1, int pageSize = 3);
    }
}
