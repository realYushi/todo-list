using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data; // Ensure this namespace correctly references where your ToDoListContext is located
using Microsoft.Extensions.DependencyInjection;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;
using ToDoListAPI.Repositories;

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


    //database
    var dbConnectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    services.AddDbContext<ToDoListContext>(options =>
        options.UseSqlServer(dbConnectionString));
    //repositories
    services.AddScoped<ITaskRepository, TaskRepository>();
    services.AddScoped<IListRepository, ListRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    //services
    services.AddScoped<ITaskService, TaskService>();
    services.AddScoped<IListService, ListService>();
    services.AddScoped<IUserService, UserService>();
    //utilities
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddAutoMapper(typeof(Program));


}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    ApplyMigrations(app);
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