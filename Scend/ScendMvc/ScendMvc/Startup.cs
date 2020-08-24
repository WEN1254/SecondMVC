using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ScendMvc.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScendMvc.Models;
using SignalRChat.Hubs;
using Microsoft.AspNetCore.Identity.UI.Services;
using ScendMvc.Areas.Identity.Pages.Servier;

namespace ScendMvc
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
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<ScendMVCContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSignalR();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Sender=> 
            {
                Sender.SendGridUser = "WWlombCZSgik6kuzZXJ-yw";
                Sender.SendGridKey = "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";
            });

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "110616841506-3ahmg8p66sphh3v8d86vslllvd7m7a0f.apps.googleusercontent.com";
                googleOptions.ClientSecret = "DAM2-LRoLVwE5FumOve56NI-";
            })
            .AddFacebook(Facebookoptions =>
            {
                Facebookoptions.AppId = "752358715566348";
                Facebookoptions.AppSecret = "8c9a9ab0c144de80a09f2cfdcd286fe1";
            });
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
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chathub");
            });

        }
    }
}
