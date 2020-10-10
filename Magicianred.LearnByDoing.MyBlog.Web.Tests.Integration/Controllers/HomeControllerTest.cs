using Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration.Helpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IHost _factory;
        private HttpClient _client;
        //private IServiceScope _scope;
        //private IConfiguration _configuration;

        #region SetUp and TearDown
        [OneTimeSetUp]
        public void SetupOneTime()
        {
            var hostBuilder = CreateHostBuilderTestHelper.GetHostBuilderTest();
            _factory = hostBuilder.Start();
            _client = _factory.GetTestClient();

            //_configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.Development.json")
            //    .Build();
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            _client.Dispose();
            _factory.Dispose();
        }
        #endregion

        [Test]
        [Category("Integration Test")]
        public async Task should_retrieve_all_posts()
        {
            // Arrange
            var endpoint = "/home";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
            Assert.That(responseString.Contains("<li class=\"post-item post-id"));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [Category("Integration Test")]
        public async Task should_retrieve_post_by_id(int id)
        {
            // Arrange
            var endpoint = string.Format("/home/post/{0}", id.ToString());

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
            Assert.That(responseString.Contains(String.Format("<article class=\"post-details post-id-{0}\">", id.ToString())));
        }

        [Test]
        [Category("Integration Test")]
        public async Task should_retrieve_no_one_post()
        {
            // Arrange
            var endpoint = "/home/post/1000";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode == HttpStatusCode.OK);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
            Assert.That(responseString.Contains("<p>Post Not Found</p>"));
        }
    }
}
