using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Models
{
    public partial class Post : IPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
