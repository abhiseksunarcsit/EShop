using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Yscp.Core.IRepositories;
using Yscp.Core.Repositories;
using Yscp.Data;
using Yscp.Services.Interfaces;
using Yscp.Services.Services;

namespace Yscp.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<YscpDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<YscpDbContext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IAccountRepositories,AccountRepositories>();
            builder.Services.AddTransient<IAccountServices,AccountServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}