using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models
{
    public interface IPost
    {
        int Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }
    }
}
