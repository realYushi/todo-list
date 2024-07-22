using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.Data;
using ToDoListAPI.Data.Repositories;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.CookiePolicy;

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
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureApp(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddCors(options =>
   {
       options.AddPolicy("AllowSpecificOrigin",
           builder =>
           {
               builder.WithOrigins("https://localhost:5173") // Replace with your allowed origins
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials(); // Add this if you're using credentials (cookies)
           });
   });
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured"))),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["jwt"];
                    return Task.CompletedTask;
                }
            };
        });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    var dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");

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
    services.AddScoped<IAuthService, AuthService>();
    // Utilities
    services.AddAutoMapper(typeof(Program));

    // Logging
    services.AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
        loggingBuilder.AddDebug();
    });

    services.AddHttpContextAccessor();
}

void ConfigureApp(WebApplication app)
{
    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigin");
    app.UseAuthentication();
    app.UseAuthorization();


    app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Strict,
        HttpOnly = HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.Always
    });

    app.MapControllers();
    ApplyMigrations(app);
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
            dbContext.Database.Migrate();
            logger.LogInformation("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while applying database migrations.");
        }
    }
}