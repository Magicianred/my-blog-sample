using Magicianred.LearnByDoing.MyBlog.BL.Services;
using Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Helpers;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Magicianred.LearnByDoing.MyBlog.BL.Tests.Unit.Services
{
    [TestFixture]
    public class CategoriesServiceTest
    {
        /// <summary>
        /// CategoriesService is our System Under Test
        /// </summary>
        private CategoriesService _sut;

        /// <summary>
        /// A mock of categories repository
        /// </summary>
        private ICategoriesRepository _categoriesRepository;

        #region SetUp and TearDown

        [OneTimeSetUp]
        public void SetupUpOneTime()
        {
            // Instance of mock
            _categoriesRepository = Substitute.For<ICategoriesRepository>();
            _sut = new CategoriesService(_categoriesRepository);
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            // dispose
            _categoriesRepository = null;
        }

        #endregion

        [Test]
        [Category("Unit test")]
        public void should_retrieve_all_categories()
        {
            // Arrange
            var mockCategories = CategoriesHelper.GetDefaultMockData();
            _categoriesRepository.GetAll().Returns(mockCategories);

            // Act
            var categories = _sut.GetAll();

            // Assert
            Assert.IsNotNull(categories);
            Assert.AreEqual(categories.Count, mockCategories.Count);
            foreach (var category in categories)
            {
                Assert.IsTrue(mockCategories.Contains(category));
                mockCategories.Remove(category);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [Category("Unit test")]
        public void should_retrieve_one_category_by_id(int id)
        {
            // Arrange
            var mockCategories = CategoriesHelper.GetDefaultMockData();
            var mockCategory = mockCategories.Where(x => x.Id == id).FirstOrDefault();

            _categoriesRepository.GetById(mockCategory.Id).Returns(mockCategory);

            // Act
            var category = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(category);
            Assert.IsTrue(category.Id == id);
        }

        [Test]
        [Category("Unit test")]
        public void should_retrieve_no_one_category()
        {
            // Arrange
            Category mockCategory = null;

            _categoriesRepository.GetById(1000).Returns(mockCategory);

            // Act
            var category = _sut.GetById(1000);

            // Assert
            Assert.IsNull(category);
        }
    }
}
