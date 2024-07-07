using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.Data;
using ToDoListAPI.Data.Repositories;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(httpsOptions =>
        {
            httpsOptions.ServerCertificate = new X509Certificate2("/app/localhost.pfx", "");
        });
    });
});
// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureApp(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    _ = services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero // Reduce the default clock skew if desired
        };
    });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Database
    var dbConnectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

    if (string.IsNullOrEmpty(dbConnectionString))
    {
        throw new InvalidOperationException("Connection string 'DefaultConnection' or environment variable 'DB_CONNECTION_STRING' is not set.");
    }

    services.AddDbContext<ToDoListContext>(options =>
        options.UseSqlServer(dbConnectionString));
    // Repositories
    services.AddScoped<ITaskRepository, TaskRepository>();
    services.AddScoped<IListRepository, ListRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    // Services
    services.AddScoped<ITaskService, TaskService>();
    services.AddScoped<IListService, ListService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IAuthService, AuthService>(); // Add this line to register AuthService
    // Utilities
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddAutoMapper(typeof(Program));

    // Logging
    services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });
}

void ConfigureApp(WebApplication app)
{
    app.UseAuthentication();
    app.UseAuthorization();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    ApplyMigrations(app);
    app.UseHttpsRedirection();
    app.MapControllers();
}

void ApplyMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        var dbContext = services.GetRequiredService<ToDoListContext>();

        try
        {
            dbContext.Database.Migrate(); // Applies all pending migrations
            logger.LogInformation("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while applying database migrations.");
        }
    }
}