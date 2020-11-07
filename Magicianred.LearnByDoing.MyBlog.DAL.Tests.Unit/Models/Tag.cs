using ServiceStack.DataAnnotations;
using System;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models
{
    /// <summary>
    /// Class for fix problem with OrmLite
    /// Use attribute Alias for correct TableName from Tag in Tags
    /// Add DateTime CreateDate because of is returned from OrmLite, if not present exception
    /// </summary>
    [Alias("Tags")]
    public class Tag : Magicianred.LearnByDoing.MyBlog.Domain.Models.Tag
    {
        public DateTime CreateDate { get; set; }
    }
}
