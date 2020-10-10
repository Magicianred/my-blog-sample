using Magicianred.LearnByDoing.MyBlog.BL.Services;
using Magicianred.LearnByDoing.MyBlog.DAL.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Models;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Repositories;
using Magicianred.LearnByDoing.MyBlog.Domain.Interfaces.Services;
using Magicianred.LearnByDoing.MyBlog.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Magicianred.LearnByDoing.MyBlog.WebApi.Integration.Helpers
{
    public static class CreateHostBuilderTestHelper
    {
        public static IHostBuilder GetHostBuilderTest()
        {
            return new HostBuilder()
                    .ConfigureAppConfiguration((hostContext, configApp) =>
                    {
                        configApp.AddJsonFile("appsettings.json", optional: false);
                    })
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.UseTestServer();
                        webHost.ConfigureServices((hostContext, services) =>
                        {
                            services.AddScoped<IPost, Post>();
                            services.AddScoped<IPostsRepository, PostsRepository>();
                            services.AddScoped<IPostsService, PostsService>();
                        });
                        webHost.UseStartup<Startup>();
                    });
        }
    }
}
