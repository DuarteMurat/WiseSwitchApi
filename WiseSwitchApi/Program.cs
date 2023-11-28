using Microsoft.EntityFrameworkCore;
using WiseSwitchApi.Data;
using WiseSwitchApi.Entities;
using WiseSwitchApi.Repository.Interfaces;
using WiseSwitchApi.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(cfg =>
{
    cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ������������������������������������������ -_.@";

    cfg.Password.RequireDigit = false;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;
    cfg.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IIdentityManager, IdentityManager>();
//builder.Services.AddScoped<IBrandRepository, BrandRepository>();
//builder.Services.AddScoped<IFirmwareVersionRepository, FirmwareVersionRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
//builder.Services.AddScoped<IProductLineRepository, ProductLineRepository>();
//builder.Services.AddScoped<IProductSeriesRepository, ProductSeriesRepository>();
//builder.Services.AddScoped<ISwitchModelRepository, SwitchModelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();