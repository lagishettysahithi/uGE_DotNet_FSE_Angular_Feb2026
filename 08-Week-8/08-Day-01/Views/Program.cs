

using WebApplication2.Repository;
using WebApplication2.Services;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();


            builder.Services.AddTransient<IContactRepository, ContactRepository>();
            builder.Services.AddTransient<IContactService, ContactService>();

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Keep local development simple (no HTTPS port/cert requirement).
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            // Correct Static Files Middleware
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=Index}/{id?}");

            app.Run();
        }
    }
}