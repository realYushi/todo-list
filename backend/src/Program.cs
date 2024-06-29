using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data; // Ensure this namespace correctly references where your ToDoListContext is located
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureApp(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    var dbConnectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    services.AddDbContext<ToDoListContext>(options =>
        options.UseSqlServer(dbConnectionString));
}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        ApplyMigrations(app);
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

void ApplyMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoListContext>();
        try
        {
            dbContext.Database.Migrate(); // Applies all pending migrations
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"An error occurred while applying database migrations: {ex.Message}");
        }
    }
}