using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models
{
    /// <summary>
    /// Class for fix problem with OrmLite
    /// Use attribute Alias for correct TableName from Post in Posts
    /// Add DateTime CreateDate because of is returned from OrmLite, if not present exception
    /// </summary>
    [Alias("Categories")]
    public class Category : Magicianred.LearnByDoing.MyBlog.Domain.Models.Category
    {
        public DateTime CreateDate { get; set; }
    }
}
