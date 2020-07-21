using System;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;

namespace BlognoteApi.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void AddMongoDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            ConventionRegistry.Register("Camel case convention",
                new ConventionPack { new CamelCaseElementNameConvention() }, type => true);
            services.Configure<BlognoteDatabaseSettings>(configuration.GetSection(nameof(BlognoteDatabaseSettings)));
            services.AddSingleton<IBlognoteDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BlognoteDatabaseSettings>>().Value);
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<CustomJsonSerializer>();
            services.AddSingleton<AuthorService>();
            services.AddSingleton<ArticleService>();
        }
    }
}
