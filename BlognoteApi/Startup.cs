using System;
using System.Security.Claims;
using BlognoteApi.Services;
using BlognoteApi.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(bearerOptions =>
            //{
            //    bearerOptions.Authority = "http://localhost:5000";
            //    bearerOptions.Audience = "resourceapi";
            //    bearerOptions.RequireHttpsMetadata = false;
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
            //    options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            //});

            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //}).SetCompatibilityVersion(CompatibilityVersion.Latest);

            ConventionRegistry.Register("Camel case convention",
                new ConventionPack { new CamelCaseElementNameConvention() }, type => true);
            services.Configure<BlognoteDatabaseSettings>(Configuration.GetSection(nameof(BlognoteDatabaseSettings)));
            services.AddSingleton<IBlognoteDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BlognoteDatabaseSettings>>().Value);

            services.AddSingleton<CustomJsonSerializer>();
            services.AddSingleton<AuthorService>();
            services.AddSingleton<ArticleService>();

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}