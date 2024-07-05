using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using TechTalk.SpecFlow;
using ToDoListAPI.Data;
using Testcontainers.MsSql;
using Microsoft.EntityFrameworkCore;
using System;

namespace feature_tests.Hooks
{
    [Binding]
    public class DatabaseHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private MsSqlContainer _msSqlContainer;
        public static HttpClient HttpClient { get; private set; }
        private static TestServer _testServer;

        public DatabaseHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [BeforeScenario]
        public async System.Threading.Tasks.Task StartContainer()
        {
            _msSqlContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04")
                .Build();

            await _msSqlContainer.StartAsync().ConfigureAwait(false);

            var builder = WebApplication.CreateBuilder();
            // Add services to the container.
            builder.Services.AddControllers(); // Assuming using MVC controllers
                                               // Use custom services or settings like DbContext.
            builder.Services.AddDbContext<ToDoListContext>((serviceProvider, options) =>
                options.UseSqlServer(_msSqlContainer.GetConnectionString()));

            _testServer = new TestServer(builder.WebHost);
            HttpClient = _testServer.CreateClient();

            var context = _testServer.Services.GetRequiredService<ToDoListContext>();
            _scenarioContext["DbContext"] = context;
            await context.Database.MigrateAsync().ConfigureAwait(false);
            await context.Database.BeginTransactionAsync().ConfigureAwait(false);
        }
        [AfterScenario]
        public async System.Threading.Tasks.Task StopContainer()
        {
            if (_scenarioContext.TryGetValue("DbContext", out ToDoListContext context))
            {
                if (context.Database.CurrentTransaction != null)
                {
                    await context.Database.RollbackTransactionAsync().ConfigureAwait(false);
                }
                context.Dispose();
            }

            if (_msSqlContainer != null)
            {
                await _msSqlContainer.StopAsync().ConfigureAwait(false);
            }
            HttpClient.Dispose();
            _testServer.Dispose();
        }
    }
}
