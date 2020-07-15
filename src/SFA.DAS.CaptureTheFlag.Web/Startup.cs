using System;
using DAS_Capture_The_Flag.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DAS_Capture_The_Flag.Data;
using DAS_Capture_The_Flag.Models;
using DAS_Capture_The_Flag.Services;
using DAS_Capture_The_Flag.Application.Repositories.GameRepository;
using DAS_Capture_The_Flag.Hubs;
using MediatR;
using DAS_Capture_The_Flag.Application.Handlers.JoinOrCreateGame;
using Microsoft.AspNetCore.ResponseCompression;
using System.Linq;
using DAS_Capture_The_Flag.MapService;
using DAS_Capture_The_Flag.Web.Handlers.GetPlayerDetails;

namespace DAS_Capture_The_Flag
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GameDbConnection")));

            //services.AddDefaultIdentity<IdentityUser>(
            //        options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<ApplicationUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddSingleton<IGameRepository>(new GameRepository());
            services.AddSignalR();
            services.AddRazorPages();
            services.AddScoped<IForumService, ForumService>();
            services.AddServerSideBlazor();
            services.AddMediatR(typeof(JoinOrCreateGameHandler));
            services.AddMediatR(typeof(GetPlayerDetailsHandler));
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddSingleton<IMap>(new Map());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapHub<GameHub>("/gamehub");
            });
        }
    }
}
