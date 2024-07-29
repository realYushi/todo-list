using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoListAPI.Data;
using ToDoListAPI.Data.Repositories;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Services;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);
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
               builder.WithOrigins("https://todo.yushi91.com", "https://todoapi.yushi91.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
           });
   });
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
    {
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["Jwt:Key"];
        var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["Jwt:Issuer"];
        var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["Jwt:Audience"];

        if (string.IsNullOrEmpty(jwtKey))
            throw new InvalidOperationException("JWT Key is not configured");
        if (string.IsNullOrEmpty(jwtIssuer))
            throw new InvalidOperationException("JWT Issuer is not configured");
        if (string.IsNullOrEmpty(jwtAudience))
            throw new InvalidOperationException("JWT Audience is not configured");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            ClockSkew = TimeSpan.Zero
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
        MinimumSameSitePolicy = SameSiteMode.Lax,
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