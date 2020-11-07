using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models
{
    public interface IPostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
