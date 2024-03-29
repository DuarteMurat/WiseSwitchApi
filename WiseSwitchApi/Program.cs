using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WiseSwitchApi.Data;
using WiseSwitchApi.Helpers;
using WiseSwitchApi.Identity;
using WiseSwitchApi.Repository;
using WiseSwitchApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// -- Add services to the container --

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

builder.Services.AddTransient<InitDb>();

builder.Services.AddScoped<IIdentityManager, IdentityManager>();

builder.Services.AddScoped<IDataUnit, DataUnit>();

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IFirmwareVersionRepository, FirmwareVersionRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IProductLineRepository, ProductLineRepository>();
builder.Services.AddScoped<IProductSeriesRepository, ProductSeriesRepository>();
builder.Services.AddScoped<ISwitchModelRepository, SwitchModelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ControllerHelper>();
builder.Services.AddScoped<DataService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

await InitDatabase(app);
async Task InitDatabase(IHost host)
{
    var scopedFactory = host.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory?.CreateScope();

    var initDb = scope?.ServiceProvider.GetService<InitDb>();

    await initDb.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Map endpoint for all switch data.
app.MapGet(
    pattern: "/api/GetAllForDesktopApp",
    handler: (DataContext dataContext) => Results.Ok(
        dataContext.Brands
            .Select(brand => new
            {
                brand.Name,
                ProductLines = brand.ProductLines.Select(productLine => new
                {
                    productLine.Name,
                    ProductSeries = productLine.ProductSeries.Select(productSeries => new
                    {
                        productSeries.Name,
                        SwitchModels = productSeries.SwitchModel.Select(switchModel => new
                        {
                            Name = switchModel.ModelName
                        })
                    })
                })
            })));

app.Run();
