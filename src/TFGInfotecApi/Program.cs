var builder = WebApplication.CreateBuilder(args);

builder.Services.GetServices();
builder.Services.AddDatabaseContext();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithOptions();
builder.Services.AddAuthenticationJwtBearer(builder.Configuration);

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ApplicationDbContext>();
	context.Database.Migrate();
}

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
