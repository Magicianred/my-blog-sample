using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models;

namespace Magicianred.LearnByDoing.MyBlog.Domain.Models
{
    /// <summary>
    /// Class pagination
    /// </summary>
    public class Pagination : IPagination
    {
        // Current page to show
        public int PageNumber { get; set; } = 1;
        // How items for page
        public int PageSize { get; set; } = 3;
    }
}
