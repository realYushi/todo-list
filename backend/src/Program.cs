using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data; // Ensure this namespace correctly references where your ToDoListContext is located
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Retrieve the connection string from appsettings.json or environment variables
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                        ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

// Correctly configure ToDoListContext with the resolved connection string
builder.Services.AddDbContext<ToDoListContext>(options =>
    options.UseSqlServer(dbConnectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToDoListContext>();
    dbContext.Database.Migrate(); // This line applies all pending migrations
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers to endpoints
app.MapControllers();

app.Run();
