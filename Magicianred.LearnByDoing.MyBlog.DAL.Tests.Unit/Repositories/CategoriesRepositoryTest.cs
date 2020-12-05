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
    public class CategoriesRepositoryTest
    {
        /// <summary>
        /// PostsService is our System Under Test
        /// </summary>
        private CategoriesRepository _sut;
        private IConfiguration _configuration;
        private IDatabaseConnectionFactory _connectionFactory;


        #region SetUp and TearDown

        [OneTimeSetUp]
        public void SetupUpOneTime()
        {
            // Instance of mock
            _configuration = Substitute.For<IConfiguration>();
            _connectionFactory = Substitute.For<IDatabaseConnectionFactory>();
            _sut = new CategoriesRepository(_connectionFactory, _configuration);
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
        public void should_retrieve_all_categories()
        {
            // Arrange
            var mockCategories = CategoriesHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Category>(mockCategories);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            // Act
            var categories = _sut.GetAll();
            var categoriesList = categories.ToList();

            // Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(categories.Count(), mockCategories.Count);

            mockCategories = mockCategories.OrderBy(o => o.Id).ToList();
            categoriesList = categoriesList.OrderBy(o => o.Id).ToList();

            for (var i = 0; i < mockCategories.Count; i++)
            {
                var mockCategory = mockCategories[0];
                var category = categoriesList[0];
                Assert.IsTrue(mockCategory.Id == category.Id);
                Assert.IsTrue(mockCategory.Name == category.Name);
                Assert.IsTrue(mockCategory.Description == category.Description);
            }
        }

        [TestCase(1)]
        [TestCase(1)]
        [Category("Unit test")]
        public void should_retrieve_category_by_id(int id)
        {
            // Arrange
            var mockCategories = CategoriesHelper.GetDefaultMockData();

            var db = new InMemoryDatabase();
            db.Insert<Category>(mockCategories);

            // insert post because of InMemory DB must have table Posts
            var mockPosts = PostsHelper.GetDefaultMockData();
            db.Insert<Post>(mockPosts);

            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            var mockCategory = mockCategories.Where(x => x.Id == id).FirstOrDefault();

            // Act
            var post = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(post);

            Assert.IsTrue(mockCategory.Id == post.Id);
            Assert.IsTrue(mockCategory.Name == post.Name);
            Assert.IsTrue(mockCategory.Description == post.Description);

        }

        [Test]
        [Category("Unit test")]
        public void should_retrieve_no_one_category()
        {
            // Arrange
            var mockCategories = CategoriesHelper.GetDefaultMockData();
            var db = new InMemoryDatabase();
            db.Insert<Category>(mockCategories);
            _connectionFactory.GetConnection().Returns(db.OpenConnection());

            // Act
            var category = _sut.GetById(1000);

            // Assert
            Assert.IsNull(category);

        }
    }
}