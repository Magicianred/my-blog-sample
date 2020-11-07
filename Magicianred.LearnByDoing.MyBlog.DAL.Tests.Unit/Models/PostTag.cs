using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models
{
    /// <summary>
    /// Class for fix problem with OrmLite
    /// Use attribute Alias for correct TableName from PostTag in PostTags
    /// Add DateTime CreateDate because of is returned from OrmLite, if not present exception
    /// </summary>
    [Alias("PostTags")]
    public class PostTag : Magicianred.LearnByDoing.MyBlog.Domain.Models.PostTag
    {
    }
}
