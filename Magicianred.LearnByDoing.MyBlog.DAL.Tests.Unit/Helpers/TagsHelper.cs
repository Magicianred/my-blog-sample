using Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Helpers
{
    public static class TagsHelper
    {
        public static List<Tag> GetDefaultMockData()
        {
            List<Tag> mockTags = new List<Tag>();
            mockTags.Add(new Tag()
            {
                Id = 1,
                Name = "Tag 1",
                Description = "Description for tag 1"
            });
            mockTags.Add(new Tag()
            {
                Id = 2,
                Name = "Tag 2",
                Description = "Decription for tag 2"
            });
            return mockTags;
        }

        public static List<Tag> GetMockDataWithPosts(List<Post> mockPosts)
        {
            List<Tag> mockTags = TagsHelper.GetDefaultMockData();
            mockTags[0].Posts = new List<Domain.Models.Post>();
            mockTags[0].Posts.Add(mockPosts[0]);
            mockTags[0].Posts.Add(mockPosts[1]);
            mockTags[1].Posts = new List<Domain.Models.Post>();
            mockTags[1].Posts.Add(mockPosts[0]);
            mockTags[1].Posts.Add(mockPosts[1]);
            return mockTags;
        }
    }
}
