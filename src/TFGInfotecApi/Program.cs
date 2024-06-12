using Microsoft.EntityFrameworkCore;
using TFGInfotecApi.DataSource;
using TFGInfotecApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Context Dependency Injection
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa;Password={dbPassword}";

builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information));

// Register manager services
builder.Services.AddManagers();

builder.Services.AddControllers();
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