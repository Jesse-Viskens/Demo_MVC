using DemoMVC.BLL;
using DemoMVC.BLL.Services.Auto;
using DemoMVC.DAL;
using DemoMVC.DAL.Data;
using DemoMVC.DAL.Data.Repositories.Auto;
using DemoMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Serilog;

namespace DemoMVC
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

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VoertuigDbContext>()
                .AddDefaultTokenProviders();

            services.RegisterBLL();
            services.RegisterDAL(Configuration);


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;

            });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/Index";

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider servicesProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            //app.UseSerilogRequestLogging();

            app.UseStatusCodePagesWithRedirects("/MyStatusCode?code={0}");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(servicesProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            Task<IdentityResult> roleResult;


            Task<bool> adminExists =  roleManager.RoleExistsAsync("Administrator");

            if (!adminExists.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
                roleResult.Wait();
            }

            //Task<bool> normalExists = roleManager.RoleExistsAsync("NormalUser");

            //if (!normalExists.Result)
            //{
            //    roleResult = roleManager.CreateAsync(new IdentityRole("NormalUser"));
            //    roleResult.Wait();
            //}
            string email = "Admin@admin.be";
            Task<IdentityUser> adminUser =  userManager.FindByEmailAsync(email);
            adminUser.Wait();

            if(adminUser.Result == null)
            {
                //create new user
                IdentityUser admin = new IdentityUser();
                admin.Email = email;
                admin.UserName = email;

                Task<IdentityResult> newAdmin = userManager.CreateAsync(admin, "Testje123!");
                newAdmin.Wait();

                if (newAdmin.Result.Succeeded)
                {
                    Task<IdentityResult>adminWithRole =  userManager.AddToRoleAsync(admin, "Administrator");
                    adminWithRole.Wait();
                }
            }
        }
    }
}
