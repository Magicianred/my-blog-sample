using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.DAL.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.BL.Services;
using Microsoft.AspNetCore.Hosting;

namespace Magicianred.LearnByDoing.MyBlog.Web.Tests.Integration.Helpers
{
    public static class CreateHostBuilderTestHelper
    {
        public static IHostBuilder GetHostBuilderTest()
        {
            return new HostBuilder()
                    .ConfigureAppConfiguration((hostContext, configApp) =>
                    {
                        configApp.AddJsonFile("testsettings.json", optional: false);
                    })
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.UseTestServer();
                        webHost.ConfigureServices((hostContext, services) =>
                        {
                            services.AddScoped<IPost, Post>();
                            services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
                            services.AddScoped<IPostsRepository, PostsRepository>();
                            services.AddScoped<IPostsService, PostsService>();
                        });
                        webHost.UseStartup<Startup>();
                    });
        }
    }
}
