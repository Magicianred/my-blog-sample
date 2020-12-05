using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.BL.Services
{
    /// <summary>
    /// Service of tags
    /// </summary>
    public class TagsService : ITagsService
    {
        private ITagsRepository tagsRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public TagsService(ITagsRepository tagsRepository)
        {
            this.tagsRepository = tagsRepository;
        }

        /// <summary>
        /// Retrieve all tags
        /// </summary>
        /// <returns>list of tags</returns>
        public List<Tag> GetAll()
        {
            return tagsRepository.GetAll().ToList();
        }
        public List<Tag> GetPaginatedAll(int page, int pageSize)
        {
            return tagsRepository.GetPaginatedAll(page, pageSize).ToList();
        }

        /// <summary>
        /// Retrieve the tag by own id
        /// </summary>
        /// <param name="id">id of tag to retrieve</param>
        /// <returns>the tag, null if id not found</returns>
        public Tag GetById(int id, int page = 1, int pageSize = 3)
        {
            return tagsRepository.GetById(id, page, pageSize);
        }

    }
}
