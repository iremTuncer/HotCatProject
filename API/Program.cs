using BLL.IService;
using BLL.Repository;
using BLL.Service;
using DAL.Context;
using IOC;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<HotCatDbContext>(options =>
    options.UseSqlServer("Server=LAPTOP-H0G4BUKB\\SQLEXPRESS;Database=HotCatDb;Integrated Security = True; trustServerCertificate=true"));

IOCContainer.ConfigureIoc(builder.Services);

//builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.adds<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
