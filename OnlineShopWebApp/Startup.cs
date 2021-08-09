using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using Serilog;
using System;
using EmailService;

namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("online_shop_kozyreva");
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connection));
            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(connection));

            services.AddDbContext<IdentityContext>(options =>
                            options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Login/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddTransient<IProductsRepository, ProductsDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<ICompareRepository, ComparesDbRepository>();
            services.AddTransient<IFavoritesRepository, FavoritesDbRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            services.AddControllersWithViews();
            services.AddTransient<ImagesProvider>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            services.AddMemoryCache();
            services.AddHostedService<ProductsCache>();

            var emailConfig = Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{sign?}");
            });
        }
    }
}
