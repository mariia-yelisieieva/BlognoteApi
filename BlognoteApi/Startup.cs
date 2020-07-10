using System;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;

namespace BlognoteApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConventionRegistry.Register("Camel case convention",
                new ConventionPack { new CamelCaseElementNameConvention() }, type => true);

            services.Configure<BlognoteDatabaseSettings>(Configuration.GetSection(nameof(BlognoteDatabaseSettings)));

            services.AddSingleton<IBlognoteDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BlognoteDatabaseSettings>>().Value);

            services.AddSingleton<JsonSerializer>();
            services.AddSingleton<AuthorService>();
            services.AddSingleton<ArticleService>();

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
