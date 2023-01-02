using DAL.Context;
using Entity.Entity;
using IOC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WEB.Externals;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // Sets the default scheme to cookies
            .AddCookie(options => options.LoginPath = "/login");

        // claims transformation is run after every Authenticate call
        builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

        builder.Services.AddDbContext<HotCatDbContext>(options =>
options.UseSqlServer("Server=LAPTOP-H0G4BUKB\\SQLEXPRESS;Database=HotCatDb;Integrated Security = True; trustServerCertificate=true"));

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        IOCContainer.ConfigureIoc(builder.Services);
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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}