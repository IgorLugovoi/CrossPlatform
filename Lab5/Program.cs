using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using LabsLibrary;

namespace Lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout"; 
                    options.AccessDeniedPath = "/Account/AccessDenied"; 
                });

            builder.Services.AddControllersWithViews();

            // Додаємо сервіс LabRunner для використання в контролерах
            builder.Services.AddSingleton<LabRunner>();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();  
            }

            app.UseHttpsRedirection();  
            app.UseStaticFiles(); 
            app.UseRouting();  


            app.UseAuthentication();  
            app.UseAuthorization();   


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();  
        }
    }
}
