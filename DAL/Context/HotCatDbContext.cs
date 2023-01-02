using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class HotCatDbContext:DbContext
    {
        public HotCatDbContext(DbContextOptions<HotCatDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=LAPTOP-H0G4BUKB\\SQLEXPRESS;Database=HotCatDb;Integrated Security = True; trustServerCertificate=true");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SelectedMenu> SelectedMenus { get; set; }

    }
}
