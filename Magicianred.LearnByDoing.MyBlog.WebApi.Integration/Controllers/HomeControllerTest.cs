using Magicianred.LearnByDoing.MyBlog.WebApi.Tests.Integration.Helpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Magicianred.LearnByDoing.MyBlog.WebApi.Tests.Integration.Controllers
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
            var endpoint = "/api/home";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [Category("Integration Test")]
        public async Task should_retrieve_post_by_id(int id)
        {
            // Arrange
            var endpoint = string.Format("/api/home/{0}", id.ToString());

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
        }

        [Test]
        [Category("Integration Test")]
        public async Task should_retrieve_no_one_post()
        {
            // Arrange
            var endpoint = "/api/home/1000";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode == HttpStatusCode.NoContent);
            Assert.That(string.IsNullOrWhiteSpace(responseString));
        }
    }
}
