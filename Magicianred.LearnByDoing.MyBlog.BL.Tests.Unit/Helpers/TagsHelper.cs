using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Helpers
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
                Description = "This is a description for tag 1"
            });
            mockTags.Add(new Tag()
            {
                Id = 2,
                Name = "Tag 2",
                Description = "This is a description for tag 2"
            });
            return mockTags;
        }
    }
}