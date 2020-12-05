using Magicianred.LearnByDoing.MyBlog.BL.Services;
using Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Helpers;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Services
{
    [TestFixture]
    public class PostsServiceTest
    {
        /// <summary>
        /// PostsService is our System Under Test
        /// </summary>
        private PostsService _sut;

        /// <summary>
        /// A mock of posts repository
        /// </summary>
        private IPostsRepository _postsRepository;

        #region SetUp and TearDown

        [OneTimeSetUp]
        public void SetupUpOneTime()
        {
            // Instance of mock
            _postsRepository = Substitute.For<IPostsRepository>();
            _sut = new PostsService(_postsRepository);
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            // dispose
            _postsRepository = null;
        }

        #endregion

        [Test]
        [Category("Unit test")]
        public void should_retrieve_all_posts()
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            _postsRepository.GetAll().Returns(mockPosts);

            // Act
            var posts = _sut.GetAll();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count, mockPosts.Count);
            foreach(var post in posts)
            {
                Assert.IsTrue(mockPosts.Contains(post));
                mockPosts.Remove(post);
            }
        }

        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 3)]
        [Category("Unit test")]
        public void should_retrieve_all_posts(int page, int pageSize)
        {
            // Arrange
            var mockPosts = PostsHelper.GetMockDataForPaging();
            var mockPaginatedPosts = mockPosts.Take(pageSize).Skip(page).ToList();

            _postsRepository.GetPaginatedAll(page, pageSize).Returns(mockPaginatedPosts);

            // Act
            var posts = _sut.GetPaginatedAll(page, pageSize);

            // Assert
            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Count() <= pageSize, "Posts are more than pageSize! Error");
        }

        [TestCase("Tom")]
        [TestCase("Jim")]
        [Category("Unit test")]
        public void should_retrieve_all_posts_by_author(string author)
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            var mockPostsFiltered = mockPosts.Where(w => w.Author == author).ToList();
            _postsRepository.GetAllByAuthor(author).Returns(mockPostsFiltered);

            // Act
            var posts = _sut.GetAllByAuthor(author);
            var postsList = posts.ToList();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), mockPostsFiltered.Count);

            foreach (var post in posts)
            {
                Assert.IsTrue(mockPostsFiltered.Contains(post));
                mockPostsFiltered.Remove(post);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [Category("Unit test")]
        public void should_retrieve_one_post_by_id(int id)
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            var mockPost = mockPosts.Where(x => x.Id == id).FirstOrDefault();

            _postsRepository.GetById(mockPost.Id).Returns(mockPost);

            // Act
            var post = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(post);
            Assert.IsTrue(post.Id == id);
        }

        [Test]
        [Category("Unit test")]
        public void should_retrieve_no_one_post()
        {
            // Arrange
            Post mockPost = null;

            _postsRepository.GetById(1000).Returns(mockPost);

            // Act
            var post = _sut.GetById(1000);

            // Assert
            Assert.IsNull(post);
        }
    }
}
