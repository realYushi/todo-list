using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ToDoListAPI.Data;
using Testcontainers.MsSql;
public class RepositoryTestBase
{
    protected ToDoListContext context;
    private MsSqlContainer _msSqlContainer;

    [OneTimeSetUp]
    public async Task GlobalSetup()
    {
        _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04")
            .Build();

        await _msSqlContainer.StartAsync();
    }

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ToDoListContext>()
                        .UseSqlServer(_msSqlContainer.GetConnectionString())
                        .Options;

        context = new ToDoListContext(options);
        context.Database.BeginTransaction();
    }

    [TearDown]
    public void TearDown()
    {
        context.Database.RollbackTransaction();
        context.Dispose();
    }

    [OneTimeTearDown]
    public async Task GlobalTeardown()
    {
        await _msSqlContainer.DisposeAsync();
    }
}