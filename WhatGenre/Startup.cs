using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace WhatGenre.Web
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
            services.AddControllersWithViews();
            services.AddDbContext<WhatGenreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WhatGenreContext"), b => b.MigrationsAssembly("Infrastructure")));
            services.AddIdentity<User, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WhatGenreContext>();
            services.AddTransient<IPostService, PostService>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddTransient<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
      
            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/login/account_login");
            services.AddRazorPages();
            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WhatGenreContext context)
        {
            //context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // add home area and map route

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapAreaControllerRoute(
                    name: "ForumArea",
                    areaName: "Forum",
                    pattern: "Forum/{controller=Forum}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "StoreArea",
                    areaName: "Store",
                    pattern: "Store/{controller=Store}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

           

        }
    }
}
