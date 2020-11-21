using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models
{
    public interface IPost
    {
        int Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }
        int CategoryId { get; set; }

        string Author { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
