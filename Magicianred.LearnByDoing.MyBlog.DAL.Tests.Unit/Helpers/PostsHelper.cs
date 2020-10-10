using Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Helpers
{
    public static class PostsHelper
    {
        public static List<Post> GetDefaultMockData()
        {
            List<Post> mockPosts = new List<Post>();
            mockPosts.Add(new Post()
            {
                Id = 1,
                Title = "This is a title for post 1",
                Text = "This is a text for post 1"
            });
            mockPosts.Add(new Post()
            {
                Id = 2,
                Title = "This is a title for post 2",
                Text = "This is a text for post 2"
            });
            return mockPosts;
        }
    }
}