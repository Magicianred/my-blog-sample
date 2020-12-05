namespace Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models
{
    /// <summary>
    /// Interface for pagination
    /// </summary>
    public interface IPagination
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
