using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Helpers
{
    public static class CategoriesHelper
    {
        public static List<Category> GetDefaultMockData()
        {
            List<Category> mockCategories = new List<Category>();
            mockCategories.Add(new Category()
            {
                Id = 1,
                Name = "Name for category 1",
                Description = "This is a description for category 1"
            });
            mockCategories.Add(new Category()
            {
                Id = 2,
                Name = "Name for category 2",
                Description = "This is a description for category 2"
            });
            return mockCategories;
        }
    }
}
