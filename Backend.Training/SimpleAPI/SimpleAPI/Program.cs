
using Microsoft.EntityFrameworkCore;
using SimpleAPI.BusinessLogicLayer.Mapping;
using SimpleAPI.BusinessLogicLayer.Services;
using SimpleAPI.DataAccessLayer;
using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SecretContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("SimpleAPI")));
builder.Services.AddScoped<ICaregoryService, CategoryService>();
builder.Services.AddScoped<ISecretRepository, SecretRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ISecretService, SecretService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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