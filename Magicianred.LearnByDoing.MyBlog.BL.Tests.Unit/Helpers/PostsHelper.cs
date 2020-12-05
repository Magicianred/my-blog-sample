using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System.Collections.Generic;

namespace Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Helpers
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
                Text = "This is a text for post 1",
                Author = "Tom"
            });
            mockPosts.Add(new Post()
            {
                Id = 2,
                Title = "This is a title for post 2",
                Text = "This is a text for post 2",
                Author = "Jim"
            });
            return mockPosts;
        }
        public static List<Post> GetMockDataForPaging()
        {
            List<Post> mockPosts = new List<Post>();
            mockPosts.AddRange(PostsHelper.GetDefaultMockData());

            mockPosts.Add(new Post()
            {
                Id = 3,
                Title = "This is a title for post 3",
                Text = "This is a text for post 3",
                Author = "Tom"
            });
            mockPosts.Add(new Post()
            {
                Id = 4,
                Title = "This is a title for post 4",
                Text = "This is a text for post 4",
                Author = "Jim"
            });
            return mockPosts;
        }
    }
}
