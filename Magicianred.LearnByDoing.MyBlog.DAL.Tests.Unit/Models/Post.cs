using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models
{
    /// <summary>
    /// Class for fix problem with OrmLite
    /// Use attribute Alias for correct TableName from Post in Posts
    /// Add DateTime CreateDate because of is returned from OrmLite, if not present exception
    /// </summary>
    [Alias("Posts")]
    public class Post : Magicianred.LearnByDoing.MyBlog.Domain.Models.Post
    {
        public DateTime CreateDate { get; set; }
    }
}
