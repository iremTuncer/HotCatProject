using DAL.Context;
using Entity.Entity;
using IOC;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //builder.Services.AddDbContext<HotCatDbContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));
        builder.Services.AddDbContext<HotCatDbContext>(options =>
    options.UseSqlServer("Server=LAPTOP-H0G4BUKB\\SQLEXPRESS;Database=HotCatDb;Integrated Security = True; trustServerCertificate=true"));
        //builder.Services.AddIdentity<Employee, IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultTokenProviders();

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}