using Magicianred.LearnByDoing.MyBlog.DAL.Repositories;
using Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Helpers;
using Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Models;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Repositories
{
    [TestFixture]
    public class PostsRepositoryTest
    {
        /// <summary>
        /// PostsRepository is our System Under Test
        /// </summary>
        private PostsRepository _sut;

        private IConfiguration _configuration;
        private IDatabaseConnectionFactory _connectionFactory;


        #region SetUp and TearDown

        [OneTimeSetUp]
        public void SetupUpOneTime()
        {
            // Instance of mock
            _configuration = Substitute.For<IConfiguration>();
            _connectionFactory = Substitute.For<IDatabaseConnectionFactory>();
            _sut = new PostsRepository(_connectionFactory, _configuration);
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            // dispose
            //_postsRepository = null;
        }

        #endregion

        [Test]
        [Category("Unit test")]
        public void should_retrieve_all_posts()
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Post>(mockPosts);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            // Act
            var posts = _sut.GetAll();
            var postsList = posts.ToList();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), mockPosts.Count);

            mockPosts = mockPosts.OrderBy(o => o.Id).ToList();
            postsList = postsList.OrderBy(o => o.Id).ToList();

            for (var i = 0; i < mockPosts.Count; i++)
            {
                var mockPost = mockPosts[0];
                var post = postsList[0];
                Assert.IsTrue(mockPost.Id == post.Id);
                Assert.IsTrue(mockPost.Title == post.Title);
                Assert.IsTrue(mockPost.Text == post.Text);
                Assert.IsTrue(mockPost.Author == post.Author);
            }
        }

        [TestCase(1, 3)]
        [TestCase(2, 3)]
        [TestCase(3, 3)]
        [Category("Unit test")]
        public void should_retrieve_all_paginated_posts(int page, int pageSize)
        {
            // Arrange
            var mockPosts = PostsHelper.GetMockDataForPaging();
            var db = new InMemoryDatabase();
            db.Insert<Post>(mockPosts);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());
            //// sqllite pagination syntax is like mysql
            //_configuration.GetSection("DatabaseType").Value.Returns("mysql");

            // Act
            var posts = _sut.GetPaginatedAll(page, pageSize);
            var postsList = posts.ToList();

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

            var db = new InMemoryDatabase();
            db.Insert<Post>(mockPosts);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            // Act
            var posts = _sut.GetAllByAuthor(author);
            var postsList = posts.ToList();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), mockPostsFiltered.Count);

            mockPostsFiltered = mockPosts.OrderBy(o => o.Id).ToList();
            postsList = postsList.OrderBy(o => o.Id).ToList();

            for (var i = 0; i < mockPostsFiltered.Count; i++)
            {
                var mockPost = mockPostsFiltered[0];
                var post = postsList[0];
                Assert.IsTrue(author == post.Author);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [Category("Unit test")]
        public void should_retrieve_post_by_id(int id)
        {
            // Arrange
            var mockTags = TagsHelper.GetDefaultMockData();
            var mockPosts = PostsHelper.GetDefaultMockData();
            var mockPostTags = PostTagsHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Tag>(mockTags);
            db.Insert<Post>(mockPosts);
            db.Insert<PostTag>(mockPostTags);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            var mockPost = mockPosts.Where(x => x.Id == id).FirstOrDefault();

            // Act
            var post = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(post);

            Assert.IsTrue(mockPost.Id == post.Id);
            Assert.IsTrue(mockPost.Title == post.Title);
            Assert.IsTrue(mockPost.Text == post.Text);
            Assert.IsTrue(mockPost.Author == post.Author);
        }

        [TestCase(1)]
        [TestCase(2)]
        [Category("Unit test")]
        public void should_retrieve_post_with_tag_by_id(int id)
        {
            // Arrange
            var mockTags = TagsHelper.GetDefaultMockData();
            var mockPosts = PostsHelper.GetMockDataWithTags(mockTags);
            var mockPostTags = PostTagsHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Tag>(mockTags);
            db.Insert<Post>(mockPosts);
            db.Insert<PostTag>(mockPostTags);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            var mockPost = mockPosts.Where(x => x.Id == id).FirstOrDefault();

            // Act
            var post = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(post);

            Assert.IsTrue(mockPost.Id == post.Id);
            Assert.IsTrue(mockPost.Title == post.Title);
            Assert.IsTrue(mockPost.Text == post.Text);
            Assert.IsNotNull(post.Tags);
            Assert.IsTrue(post.Tags.Count() == 1);
            for (int i = 0; i < post.Tags.Count; i++)
            {
                Assert.IsTrue(mockPost.Tags[i].Id == post.Tags[i].Id);
                Assert.IsTrue(mockPost.Tags[i].Name == post.Tags[i].Name);
                Assert.IsTrue(mockPost.Tags[i].Description == post.Tags[i].Description);
            }

        }

        [Test]
        [Category("Unit test")]
        public void should_retrieve_no_one_post()
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Post>(mockPosts);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            // Act
            var post = _sut.GetById(1000);

            // Assert
            Assert.IsNull(post);

        }
    }
}
